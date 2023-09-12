'use strict';

function maxNumber(input) {
    let maxNum = Number.NEGATIVE_INFINITY;
    let idx = 0;

    while (true) {
        let currCmd = input[idx];

        if (currCmd === "Stop") {
            break;
        }

        let currNum = Number(currCmd);
        if (maxNum < currNum) {
            maxNum = currNum;
        }

        idx++;
    }

    console.log(maxNum);
}

maxNumber(["45", "-20", "7", "99", "Stop"]);



