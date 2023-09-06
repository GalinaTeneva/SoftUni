'use strict';

function numbersDivisibleByNine(input) {
    let firstNum = Number(input[0]);
    let secondNum = Number(input[1]);

    let sum = 0;
    let numbers = "";
    for (let i = firstNum; i <= secondNum; i++) {

        if (i % 9 === 0) {
            sum += i;
            numbers += i + "\n"; 
        }
    }

    console.log(`The sum: ${sum}`);
    console.log(numbers);
}

numbersDivisibleByNine(["100", "200"]);