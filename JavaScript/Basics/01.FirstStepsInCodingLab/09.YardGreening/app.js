'use strict';

function yardGreening(input) {

    let pricePerSquareMetre = 7.61;
    let discount = 0.18;

    let areaForGreening = input[0];

    let priceWithoutDiscount = areaForGreening * pricePerSquareMetre;
    let discountAmount = priceWithoutDiscount * discount;

    console.log(`The final price is: ${priceWithoutDiscount - discountAmount} lv.`);
    console.log(`The discount is: ${discountAmount} lv.`);
}

yardGreening(["150"]);
