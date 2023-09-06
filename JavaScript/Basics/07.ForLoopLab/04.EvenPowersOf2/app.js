'use strict';

function evenPowersOf2(input) {
    let number = Number(input[0]);

    for (let i = 0; i <= number; i+=2) {
        console.log(Math.pow(2,i))
    }
}

evenPowersOf2(["5"]);
