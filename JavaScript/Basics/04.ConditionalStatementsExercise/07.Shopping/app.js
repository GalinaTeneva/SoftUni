'use strict';

function shopping(input){
    const videoCardPrice = 250;
    const processorPriceRatio = 0.35;
    const memoryPriceRatio = 0.10;
    const discount = 0.15;

    let budget = Number(input[0]);
    let videoCardsCount = Number(input[1]);
    let processorsCount = Number(input[2]);
    let memoryCount = Number(input[3]);

    let videoCardsCost = videoCardPrice * videoCardsCount;
    let processorsCost = (videoCardsCost * processorPriceRatio) * processorsCount;
    let memoryCost = (videoCardsCost * memoryPriceRatio) * memoryCount;
    let totalCost = videoCardsCost + processorsCost + memoryCost;

    if (videoCardsCount > processorsCount) {
        totalCost -= totalCost * discount;
    }

    if (budget >= totalCost) {
        let diff = budget - totalCost;
        console.log(`You have ${diff.toFixed(2)} leva left!`);
    }
    else {
        let diff = totalCost - budget;
        console.log(`Not enough money! You need ${diff.toFixed(2)} leva more!`);
    }
}

shopping(["920.45", "3", "1", "1"])


