'use strict';

function petShop(input) {

    let pricePerDogFood = 2.50;
    let priceperCatFood = 4;

    let dogPackages = input[0];
    let catPackages = input[1];

    let finalPrice = dogPackages * pricePerDogFood + catPackages * priceperCatFood;

    console.log(`${finalPrice} lv.`)
}

petShop(["13 ", "9 "])
