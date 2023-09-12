'use strict';

function sequence(input) {
    let number = Number(input[0]);

    let newNum = 1;

    while (newNum <= number) {
        console.log(newNum);
        newNum = newNum * 2 + 1;
    }
}

sequence(["31"]);
