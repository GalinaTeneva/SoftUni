'use strict';

function onTimeForTheExam(input) {
    let examHour = Number(input[0]);
    let examMinute = Number(input[1]);
    let arrivalHour = Number(input[2]);
    let arrivalMinute = Number(input[3]);

    let exam = examHour * 60 + examMinute;
    let arrival = arrivalHour * 60 + arrivalMinute;
    let diff = exam - arrival;

    if (diff >= 0 && diff <= 30) {
        console.log("On time");

        if (diff != 0) {
            console.log(`${diff} minutes before the start`)
        }
    }
    else if (diff > 30) {
        console.log("Early");

        if (diff < 60) {
            console.log(`${diff} minutes before the start`);
        }
        else {
            let hour = Math.floor(diff / 60);
            let minutes = (diff % 60);

            if (minutes < 10) {
                console.log(`${hour}:0${minutes} hours before the start`);
            }
            else {
                console.log(`${hour}:${minutes} hours before the start`);
            }
        }
    }
    else if (diff < 0) {
        console.log("Late");

        diff = Math.abs(diff);
        if (diff < 60) {
            console.log(`${diff} minutes after the start`);
        }
        else {
            let hour = Math.floor(diff / 60);
            let minutes = diff % 60;

            if (minutes < 10) {
                console.log(`${hour}:0${minutes} hours after the start`);
            }
            else {
                console.log(`${hour}:${minutes} hours after the start`);
            }
        }

    }
}

onTimeForTheExam(["11", "30", "12", "29"])

