'use strict';

function equalSumsEvenOddPosition(input) {
    let firstNum = Number(input[0]);
    let secondNum = Number(input[1]);

    let result = "";
    let numbers = 0;

    for (let i = firstNum; i <= secondNum; i++) {
        let currNumString = i.toString();

        let oddSum = 0;
        let evenSum = 0;

        for (let j = 0; j < currNumString.length; j++) {
            let currDigit = Number(currNumString[j]);

            if (j % 2 === 0) {
                evenSum += currDigit;
            }
            else {
                oddSum += currDigit;
            }
        }

        if (oddSum === evenSum) {
            result += currNumString + " ";
        }
    }

    console.log(result);
}

equalSumsEvenOddPosition(["100000", "100050"]);
