"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/comsHub").build();

connection.start().then(function () {
    connection.invoke("Initialize");
}).catch(function (err) {
    return console.error(err.toString());
});

var controls = document.querySelectorAll(".control");
for (let i = 0; i < controls.length; i++) {
    const element = controls[i];
    element.addEventListener("click", function (event) 
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

    extendSession();
    event.preventDefault();
    resetAnswerDiv();
    incrementSongsPlayed();
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

document.getElementById("myAnswerButton").addEventListener("click", function (event) {
    const myAnswer = document.getElementById("myAnswerInput").value;
    connection.invoke("CheckAnswer", myAnswer).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("CurrentSong", function (song) {
    var artistElement = document.getElementById("artistname");
    artistElement.textContent = song.artistName;

    var songElement = document.getElementById("songname");
    songElement.textContent = song.songName;

    var lyricsElement = document.getElementById("lyrics");
    lyricsElement.textContent = song.lyrics;
});

connection.on("SongCount", function (count) {
    var countElement = document.getElementById("songcount");
    countElement.textContent = count;
});

connection.on("Reset", function () {
    const element = document.getElementById("songsplayed");
    element.textContent = 0;
});

connection.on("Answer", function (answerWasCorrect) {
    resetAnswerDiv();
    if (answerWasCorrect) {
        answerDivSuccess();
    }
    else {
        answerDivFailure();
    }
});

function resetAnswerDiv() {
    const element = document.getElementById("myAnswerDiv");
    element.classList.remove("alert", "alert-success", "alert-danger");

    const feedbackElement = document.getElementById("myAnswerFeedback");
    feedbackElement.textContent = "";

    const myAnswerElement = document.getElementById("myAnswerInput");
    myAnswerElement.value = "";
}

function answerDivSuccess() {
    const element = document.getElementById("myAnswerDiv");
    element.classList.add("alert", "alert-success");

    const feedbackElement = document.getElementById("myAnswerFeedback");
    feedbackElement.textContent = "Rätt!";
}

function answerDivFailure() {
    const element = document.getElementById("myAnswerDiv");
    element.classList.add("alert", "alert-danger");

    const feedbackElement = document.getElementById("myAnswerFeedback");
    feedbackElement.textContent = "Fel!";
}

function extendSession() {
    const action = async () => {
        const response = await fetch('/api/keepalive');
        console.log("Session extended.");
    }
    action();
}

function incrementSongsPlayed() {
    const element = document.getElementById("songsplayed");
    let counter = parseInt(element.textContent);
    counter++;
    element.textContent = counter;
}