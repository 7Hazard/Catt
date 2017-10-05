$(document).ready(function(){
    //UnhideAnimate();
    ChatConnect();
});

function ChatConnect(){
    socket = new WebSocket('ws://127.0.0.1:6969');
    SetSocketEventListeners();
    //socket.send("message", "JIDHOEG");
}

function ChatDisconnect(){
    socket.close();
}

function ChatReconnect(){
    ChatDisconnect();
    ChatConnect();
}

function OutputMessage(timestamp, user, message){
    document.getElementById("chatbox").innerHTML += 
        "<div class='message white-text'><p>["+
        timestamp
        +"] </p><p>"+
        user
        +": </p><p>"+
        message
        +"</p></div>";
}

var socket;

function SetSocketEventListeners(){
    socket.addEventListener('connect', function (event) {
        OutputMessage("", "Catt", "Chat loaded");
        //socket.send('Hello Server!');
    });

    socket.addEventListener('message', function (event) {
        console.log('Message from server ', event.data);
    });
}