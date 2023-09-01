'use strict';

function timePlusMinutes(input) {
    const minutesToAdd = 15;

    let hours = Number(input[0]);
    let minutes = Number(input[1]);

    let newMinutes = minutes + minutesToAdd;

    if (newMinutes > 59) {
        hours++;
        newMinutes -= 60;
    }

    if (hours > 23) {
        hours = 0;
    }

    if (newMinutes < 10) {
        console.log(`${hours}:0${newMinutes}`)
    }
    else {
        console.log(`${hours}:${newMinutes}`)
    }
}

timePlusMinutes(["23", "59"]);
