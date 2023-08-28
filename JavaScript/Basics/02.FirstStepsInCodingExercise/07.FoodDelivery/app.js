'use strict';

function foodDelivery(input) {

    const chickenMenuePrice = 10.35;
    const fishMenuePrice = 12.40;
    const veganMenuePrice = 8.15;
    const deliveryCost = 2.50;
    const desertCostInPersent = 20;

    let chickenMenuesCount = Number(input[0]);
    let fishMenuesCount = Number(input[1]);
    let veganMenuesCount = Number(input[2]);

    let amountForAllMenues = (chickenMenuesCount * chickenMenuePrice) + (fishMenuesCount * fishMenuePrice) + (veganMenuesCount * veganMenuePrice);
    let desertsAmount = amountForAllMenues * desertCostInPersent / 100;
    let finalAmount = amountForAllMenues + desertsAmount + deliveryCost;

    console.log(finalAmount);
}

foodDelivery(["2 ", "4 ", "3 "]);
