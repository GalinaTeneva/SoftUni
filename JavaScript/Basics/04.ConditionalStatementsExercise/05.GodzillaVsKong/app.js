'use strict';

function godzillaVsKong(input){
    const filmSet = 0.10;
    const discount = 0.10;

    let budged = Number(input[0]);
    let stuntmenCount = Number(input[1]);
    let clothesPrice = Number(input[2]);

    let filmSetCost = budged * filmSet;
    let clothesCost = stuntmenCount * clothesPrice;

    if (stuntmenCount >= 150) {
        clothesCost -= clothesCost * discount;
    }

    let finalCost = filmSetCost + clothesCost;

    if (budged >= finalCost) {
        let moneyDiff = budged - finalCost;
        console.log("Action!")
        console.log(`Wingard starts filming with ${moneyDiff.toFixed(2)} leva left.`)
    }
    else {
        let moneyDiff = finalCost - budged;
        console.log("Not enough money!")
        console.log(`Wingard needs ${moneyDiff.toFixed(2)} leva more.`)
    }
}

godzillaVsKong(["15437.62", "186", "57.99"])


