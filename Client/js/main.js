$(document).ready(function(){
    $('.modal').modal({
        dismissible: false
    });
    $('#connect-modal').modal('open'); // Open connect window

    $("#chat-input").keyup((event) => { // When key has gone up
        if (event.keyCode === 13) { // ENTER key
            let input = $("#chat-input").val(); // The message itself
            if( // Message is empty or disconnected
                input != ""
                && ws.readyState == ws.OPEN
            ){
                SendMessage(input);
                $("#chat-input").val("")
            }
        }
    });
});

var name;
var host;
var port;
function InputsValid(){ // Validates and sets user info
    // If inputs are valid
    if(
        $("#name-input").is(':valid')
        && $("#host-input").is(':valid')
        && $("#port-input").is(':valid')
    ){ // Assign them
        name = $('#name-input').val()
        host = $('#host-input').val()
        port = $('#port-input').val()
    } else { // else invalid
        return false;
    }

    // If inputs are empty use defaults (placeholders)
    if(name === ""){
        name = $('#name-input').attr('placeholder')
    }
    if(host === ""){
        host = $('#host-input').attr('placeholder')
    }
    if(port === ""){
        port = $('#port-input').attr('placeholder')
    }

    return true;
}

var ws;
// Connect to chat server
function ChatConnect(){
    if(InputsValid()){ // if inputs are valid
        $('#connect-modal').modal('close');
        $("#loader").removeClass("hide");
        ws = new WebSocket('ws://'+host+':'+port+'/chat?name='+name);
        SetEventListeners();
    }
}

// Disconnect
function ChatDisconnect(){
    ws.close();
}

// Reconnect
function ChatReconnect(){
    ChatDisconnect();
    $('#connect-modal').modal('open');
}

function OutputMessage(timestamp, user, message){
    $("#chat-box").append( 
        "<div class='message white-text'><p>["+
        timestamp
        +"] </p><p>"+
        user
        +": </p><p>"+
        message
        +"</p></div>"
    );
}

function SendMessage(message){
    ws.send(message);
}

function SetEventListeners(){
    // When connection is established
    ws.addEventListener('open', function (event) {
        HideLoader();
    });

    // When disconnected
    ws.addEventListener('close', function (event) {
        OutputMessage(GetTimestamp(), "Catt", "Disconnected");
    });
    
    // Manages all server messages
    ws.addEventListener('message', (event) => {
        let args = event.data.split(" ");
        switch (args[0]) {
            case "userconnect": // A client connected
            OutputMessage(args[1], "Catt", args[2]+" connected");
            break;

            case "userdisconnect": // A client disconnected
            OutputMessage(args[1], "Catt", args[2]+" disconnected");
            break;

            case "message": //  A client sent a message
            OutputMessage(args[1], args[2], args.splice(3).join(' '));
            break;
        }
    });
}

function GetTimestamp(){
    return new Date().toTimeString().split(' ')[0];
}

function HideLoader(){
    $("#loader").addClass("hide");
}