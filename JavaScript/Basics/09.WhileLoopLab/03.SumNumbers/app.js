'use strict';

function sumNumbers(input) {
    let num = Number(input[0]);
    let sum = 0;
    let idx = 1;

    while (true) {
        let currNum = Number(input[idx]);
        sum += currNum;

        if (sum >= num) {
            break;
        }

        idx++;
    }

    console.log(sum);
}

sumNumbers(["100", "10", "20", "30", "40"]);

