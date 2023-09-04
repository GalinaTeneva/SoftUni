'use strict';

function fruitShop(input) {
    let fruit = input[0];
    let day = input[1];
    let quantity = input[2];

    let isWeekend = day === "Saturday" || day === "Sunday";
    let isWorkday = day === "Monday" || day === "Tuesday" || day === "Wednesday" || day === "Thursday" || day === "Friday";
    let price = 0;

    if (isWorkday) {
        switch (fruit) {
            case "banana": price = 2.50; break;
            case "apple": price = 1.20; break;
            case "orange": price = 0.85; break;
            case "grapefruit": price = 1.45; break;
            case "kiwi": price = 2.70; break;
            case "pineapple": price = 5.50; break;
            case "grapes": price = 3.85; break;
            default: console.log("error"); break;
        }
    }
    else if (isWeekend) {
        switch (fruit) {
            case "banana": price = 2.70; break;
            case "apple": price = 1.25; break;
            case "orange": price = 0.90; break;
            case "grapefruit": price = 1.60; break;
            case "kiwi": price = 3.00; break;
            case "pineapple": price = 5.60; break;
            case "grapes": price = 4.20; break;
            default: console.log("error"); break;
        }
    }
    else {
        console.log("error");
    }

    if (price > 0) {
        let finalPrice = price * quantity;
        console.log(finalPrice.toFixed(2));
    }
}

fruitShop(["apple",
    "Workday",
    "2"])


