'use strict';

function newHouse(input) {
    let flowerType = input[0];
    let flowersQuantity = Number(input[1]);
    let budget = Number(input[2]);

    let flowerPrice = 0;
    let discount = 0;

    switch (flowerType) {
        case "Roses":
            flowerPrice = 5;

            if (flowersQuantity > 80) {
                discount = 0.1;
            }
            break;
        case "Dahlias":
            flowerPrice = 3.80;

            if (flowersQuantity > 90) {
                discount = 0.15;
            }
            break;
        case "Tulips":
            flowerPrice = 2.80;

            if (flowersQuantity > 80) {
                discount = 0.15;
            }
            break;
        case "Narcissus":
            flowerPrice = 3;

            if (flowersQuantity < 120) {
                flowerPrice += 0.15 * flowerPrice;
            }
            break;
        case "Gladiolus":
            flowerPrice = 2.50;

            if (flowersQuantity < 80) {
                flowerPrice += 0.20 * flowerPrice;
            }
            break;
    }

    let totalPrice = flowersQuantity * flowerPrice - (flowersQuantity * flowerPrice * discount);


    if (budget >= totalPrice) {
        let diff = budget - totalPrice;
        console.log(`Hey, you have a great garden with ${flowersQuantity} ${flowerType} and ${diff.toFixed(2)} leva left.`);
    }
    else {
        let diff = totalPrice - budget;
        console.log(`Not enough money, you need ${diff.toFixed(2)} leva more.`);
    }
}

newHouse(["Tulips", "88", "260"])

