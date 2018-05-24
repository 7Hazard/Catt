$(document).ready(function(){
    //UnhideAnimate();
    ChatConnect();

    $("#chat-input").keyup((event) => { // När tangenten har gått upp
        if (event.keyCode === 13) { // Enter tangenten
            let input = $("#chat-input").val(); // Meddelandet
            if( // Meddelandet inte är tomt och är ansluten
                input != ""
                && ws.readyState == ws.OPEN
            ){
                SendMessage(input);
                $("#chat-input").val("")
            }
        }
    });
});

var ws;

function ChatConnect(){
    $("#loader").removeClass("hide");
    ws = new WebSocket('ws://localhost:6969/chat');
    SetEventListeners();
}

function ChatDisconnect(){
    ws.close();
}

function ChatReconnect(){
    ChatDisconnect();
    ChatConnect();
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
    // När anslutningen öppnas
    ws.addEventListener('open', function (event) {
        //OutputMessage(GetTimestamp(), "Catt", "Connected");
        HideLoader();
    });

    // När anslutningen stängs
    ws.addEventListener('close', function (event) {
        OutputMessage(GetTimestamp(), "Catt", "Disconnected");
    });
    
    // Hanterar alla servermeddelande
    ws.addEventListener('message', (event) => {
        let args = event.data.split(" ");
        switch (args[0]) {
            case "userconnect": // En användare anslöt
            OutputMessage(args[1], "Catt", args[2]+" connected");
            break;

            case "message": // En klient skickade ett meddelande
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