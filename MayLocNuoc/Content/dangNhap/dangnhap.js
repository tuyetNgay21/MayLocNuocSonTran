function getRandomInt(max) {
    return Math.floor(Math.random() * Math.floor(max));
}

function getString() {
    var av = "";
    for (var i = 0; i < 3100; i++) {
        av += getRandomInt(2) + " ";
    }
    return av;
}

function vvc() {
    setInterval(function() {
        $("#maume").html(getString());
    }, 100);


}

$("#dn1").click(function () {
    $("#acc").css("display", "block");
    $("#pass").css("display", "block");
    $("#passnew").css("display", "none");
    $("#nhaplaimk").css("display", "none");
    $("#email2").css("display", "none"); 
    
    $("#butDN").css("display", "block");
    $("#butdmk").css("display", "none");
    $("#butlmk").css("display", "none");
});
$("#lmk1").click(function () {
    $("#acc").css("display", "block");
    $("#pass").css("display", "none");
    $("#passnew").css("display", "none");
    $("#nhaplaimk").css("display", "none");
    $("#email2").css("display", "block");
   
    $("#butDN").css("display", "none");
    $("#butdmk").css("display", "none");
    $("#butlmk").css("display", "block");
});
$("#dmk1").click(function () {
    $("#acc").css("display", "block");
    $("#pass").css("display", "block");
    $("#passnew").css("display", "block");
    $("#nhaplaimk").css("display", "block");
    $("#email2").css("display", "none");
    
    $("#butDN").css("display", "none");
    $("#butdmk").css("display", "block");
    $("#butlmk").css("display", "none");
});