'use strict';

function sumOfTwoNumbers(input) {
    let firstNum = Number(input[0]);
    let secondNum = Number(input[1]);
    let magicNum = Number(input[2]);

    let combinationsCounter = 0;
    let isFound = false;

    for (let i = firstNum; i <= secondNum; i++) {
        for (let j = firstNum; j <= secondNum; j++) {
            let currCombination = i + j;
            combinationsCounter++;

            if (currCombination === magicNum) {
                isFound = true;
                console.log(`Combination N:${combinationsCounter} (${i} + ${j} = ${magicNum})`);
                break;
            }
        }

        if (isFound) {
            break;
        }
    }

    if (!isFound) {
        console.log(`${combinationsCounter} combinations - neither equals ${magicNum}`);
    }
}

sumOfTwoNumbers(["23", "24", "20"]);


