"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/comsHub").build();

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

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

var controls = document.querySelectorAll(".control");
for (let i = 0; i < controls.length; i++) {
    const element = controls[i];
    element.addEventListener("click", function (event) {
        var data = event.currentTarget.getAttribute("data");
        connection.invoke("OpenPanel", data).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
}

document.getElementById("next").addEventListener("click", function (event) {
    connection.invoke("NextSong").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("reset").addEventListener("click", function (event) {
    connection.invoke("Reset").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
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
