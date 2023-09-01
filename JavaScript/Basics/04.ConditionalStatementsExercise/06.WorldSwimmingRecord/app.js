'use strict';

function worldSwimmingRecord(input){
    const addedTime = 12.5;

    let record = Number(input[0]);
    let distance = Number(input[1]);
    let secondsPerMeter = Number(input[2]);

    let totalAddedTme = Math.floor(distance / 15) * addedTime;
    let time = distance * secondsPerMeter + totalAddedTme;

    if (time < record) {
        time = distance * secondsPerMeter + totalAddedTme;
        console.log(`Yes, he succeeded! The new world record is ${time.toFixed(2)} seconds.`);
    }
    else {
        let diff = time - record;
        console.log(`No, he failed! He was ${diff.toFixed(2)} seconds slower.`);
    }
}

worldSwimmingRecord(["10464", "1500", "20"])




