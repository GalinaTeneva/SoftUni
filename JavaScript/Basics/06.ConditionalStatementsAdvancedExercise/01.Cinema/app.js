'use strict';

function cinema(input) {
    const PREMIERE_PRICE = 12.00;
    const NORMAL_PRICE = 7.50;
    const DISCOUNT_PRICE = 5.00;

    let type = input[0];
    let rows = Number(input[1]);
    let cols = Number(input[2]);

    let profit = 0;
    switch (type) {
        case "Premiere":
            profit = PREMIERE_PRICE * rows * cols;
            break;
        case "Normal":
            profit = NORMAL_PRICE * rows * cols;
            break;
        case "Discount":
            profit = DISCOUNT_PRICE * rows * cols;
            break;

    }

    console.log(`${profit.toFixed(2)} leva`);
}

cinema(["Normal", "21", "13"])

