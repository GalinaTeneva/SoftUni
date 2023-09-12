'use strict';

function minNumber(input) {
    let minNum = Number.MAX_VALUE;
    let idx = 0;

    while (true) {
        let currCmd = input[idx];

        if (currCmd === "Stop") {
            break;
        }

        let currNum = Number(currCmd);
        if (minNum > currNum) {
            minNum = currNum;
        }

        idx++;
    }

    console.log(minNum);
}

minNumber(["100", "99", "80", "70", "Stop"]);

