'use strict';

function toyShop(input) {
   
    const puzzelPrice = 2.60;
    const dollPrice = 3.00;
    const teddyBearPrice = 4.10;
    const minionPrice = 8.20;
    const truckToyPrice = 2;

    const quantutyDiscount = 0.25;
    const rent = 0.10;

    let tripCost = Number(input[0]);
    let puzzelQuantity = Number(input[1]);
    let dollQuantity = Number(input[2]);
    let teddyBearQuantity = Number(input[3]);
    let minionQuantity = Number(input[4]);
    let truckToyQuantity = Number(input[5]);

    let orderValue = (puzzelPrice * puzzelQuantity) + (dollPrice * dollQuantity) + (teddyBearPrice * teddyBearQuantity) + (minionPrice * minionQuantity) + (truckToyPrice * truckToyQuantity);
    let totalQuantity = puzzelQuantity + dollQuantity + teddyBearQuantity + minionQuantity + truckToyQuantity;

    if (totalQuantity >= 50) {
        orderValue -= orderValue * quantutyDiscount;
    }

    let rentValue = orderValue * rent;
    let profit = orderValue - rentValue;

    if (profit >= tripCost) {
        let moneydiff = profit - tripCost;
        console.log(`Yes! ${moneydiff.toFixed(2)} lv left.`)
    }
    else {
        let moneydiff = tripCost - profit;
        console.log(`Not enough money! ${moneydiff.toFixed(2)} lv needed.`)
    }
}

toyShop(["320", "8", "2", "5", "5", "1"])


