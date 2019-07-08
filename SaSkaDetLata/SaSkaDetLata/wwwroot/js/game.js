"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/comsHub").build();

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("OpenPanel", function (square) {
    var element = document.getElementById(square.number);
    element.textContent = square.word;

    element.classList.remove("number");
    element.classList.add("word");

    if (square.red == true) {
        element.classList.remove("blue");
        element.classList.add("red");
    }
});

connection.on("ResetNumbers", function () {
    resetNumbers();
});

function resetNumbers() {
    for (let index = 1; index < 7; index++) {
        const element = document.getElementById(index);
        element.classList.remove("word");
        element.classList.remove("red");
        element.classList.add("number");
        element.classList.add("blue");
        element.textContent = index;
    }
}
