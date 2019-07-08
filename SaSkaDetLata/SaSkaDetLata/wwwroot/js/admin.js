"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/comsHub").build();

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

document.getElementById("givescoreteam1").addEventListener("click", function (event) {
    connection.invoke("GiveScore", "team1", 1).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("givescoreteam2").addEventListener("click", function (event) {
    connection.invoke("GiveScore", "team2", 1).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});