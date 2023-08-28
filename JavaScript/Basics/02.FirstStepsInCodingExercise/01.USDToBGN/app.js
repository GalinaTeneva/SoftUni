'use strict';

function usdToBgn(input) {
    let rate = 1.79549;

    let amountToConvert = Number(input[0]);
    let result = amountToConvert * rate;
    console.log(result);
}

usdToBgn(["22"]);