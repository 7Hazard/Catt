$(document).ready(function(){
    //UnhideAnimate();
    OutputMessage("", "Catt", "Chat loaded");
});

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