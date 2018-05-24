$(document).ready(function(){
    //UnhideAnimate();
    ChatConnect();
});

var ws;

function ChatConnect(){
    $("#loader").removeClass("hide");
    ws = new WebSocket('ws://localhost:6969/chat');
    SetwsEventListeners();
}

function ChatDisconnect(){
    ws.close();
}

function ChatReconnect(){
    ChatDisconnect();
    ChatConnect();
}

function OutputMessage(timestamp, user, message){
    $("#chatbox").append( 
        "<div class='message white-text'><p>["+
        timestamp
        +"] </p><p>"+
        user
        +": </p><p>"+
        message
        +"</p></div>"
    );
}

function SendMessage(){

}

function SetwsEventListeners(){
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
        let msg = event.data.split(" ");
        switch (msg[0]) {
            case "userconnect": // En användare anslöt
            OutputMessage("", "Catt", msg[1]+" connected");
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