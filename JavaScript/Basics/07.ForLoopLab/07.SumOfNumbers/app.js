'use strict';

function sumOfNumbers(input) {
    let numberAsText = input[0];

    let sum = 0;

    for (let i = 0; i < numberAsText.length; i++) {
        let digit = Number(numberAsText[i]);
        sum += digit;
    }

    console.log(`The sum of the digits is:${sum}`);
}

sumOfNumbers(["564891"]);
