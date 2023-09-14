'use strict';

function walking(input) {
    const TARGET = 10000;

    let idx = 0;
    let totalSteps = 0;
    let isReached = false;

    while (true) {
        let cmd = input[idx];

        if (cmd === "Going home") {
            let lastSteps = Number(input[++idx]);
            totalSteps += lastSteps;

            if (totalSteps >= TARGET) {
                isReached = true;
            }

            break;
        }

        let currSteps = Number(input[idx]);
        totalSteps += currSteps;

        if (totalSteps >= TARGET) {
            isReached = true;
            break;
        }

        idx++;
    }

    if (isReached) {
        let diff = totalSteps - TARGET;
        console.log("Goal reached! Good job!");
        console.log(`${diff} steps over the goal!`);
    }
    else {

    }

    if (totalSteps < TARGET) {
        let diff = TARGET - totalSteps;

        console.log(`${diff} more steps to reach goal.`);
    }
}

walking(["1500", "300", "2500", "3000", "Going home", "200"]);
