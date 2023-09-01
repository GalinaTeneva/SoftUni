'use strict';

function lunchBreak(input){
    const lunchTimeRatio = 0.125;
    const restTimeRatio = 0.25;

    let tvShowName = input[0];
    let tvShowDuration = Number(input[1]);
    let availableTime = Number(input[2]);

    let lunchTime = availableTime * lunchTimeRatio;
    let restTime = availableTime * restTimeRatio;
    let timeForWatching = availableTime - lunchTime - restTime;

    if (timeForWatching >= tvShowDuration) {
        let diff = Math.ceil(timeForWatching - tvShowDuration);
        console.log(`You have enough time to watch ${tvShowName} and left with ${diff} minutes free time.`);
    }
    else {
        let diff = Math.ceil(tvShowDuration - timeForWatching);
        console.log(`You don't have enough time to watch ${tvShowName}, you need ${diff} more minutes.`);
    }
}

lunchBreak(["Teen Wolf", "48", "60"])


