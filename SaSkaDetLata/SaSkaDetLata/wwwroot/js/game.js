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

connection.on("Reset", function () {
    resetNumbers();
    resetScore();
});

connection.on("NextSong", function () {
    resetNumbers();
});

connection.on("OutOfSongs", function () {
    Swal.fire({
        title: 'Slut!',
        text: 'Det var alla låtar! Spela gärna igen, eller registrera fler låtar.',
        type: 'info',
    });
});

connection.on("GiveScore", function(team, increment) {
    var element = document.getElementById(team);
    var currentScore = parseInt(element.textContent);
    var newScore = currentScore + parseInt(increment);
    element.textContent = newScore;
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

function resetScore(){
    var team1 = document.getElementById("team1");
    var team2 = document.getElementById("team2");

    team1.textContent = 0;
    team2.textContent = 0;
}
