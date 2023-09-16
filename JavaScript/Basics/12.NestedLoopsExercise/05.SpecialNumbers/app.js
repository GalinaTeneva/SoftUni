'use strict';

function specialNumbers(input) {
    let number = Number(input[0]);
    let result = "";

    for (let i = 1111; i <= 9999; i++) {
        let currNum = i;
        let isMagicNum = true;
        let currDigit = currNum % 10;

        while (currNum != 0) {
            if (number % currDigit != 0) {
                isMagicNum = false;
                break;
            }

            currNum = Math.floor(currNum / 10);
            currDigit = currNum % 10;
        }

        if (isMagicNum) {
            result += i + " ";
        }
    }

    console.log(result);
}

specialNumbers(["11"]);
