'use strict';

function radiansToDegrees(input) {

    let valueInRadians = Number(input[0]);
    let valueInDegrees = valueInRadians * 180 / Math.PI;

    console.log(valueInDegrees);
}

radiansToDegrees(["3.1416"]);
