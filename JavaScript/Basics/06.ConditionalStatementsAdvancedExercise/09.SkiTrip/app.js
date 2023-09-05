'use strict';

function skiTrip(input) {
    let days = Number(input[0]) - 1;
    let accommodationType = input[1];
    let evaluation = input[2];

    let price = 0;
    let discount = 0;

    if (accommodationType === "room for one person") {
        price = 18;
    }
    else if (accommodationType === "apartment") {
        price = 25;

        if (days < 10) {
            discount = 0.30;
        }
        else if (days >= 10 && days <= 15) {
            discount = 0.35;
        }
        else if (days > 15) {
            discount = 0.50;
        }
    }
    else if (accommodationType === "president apartment") {
        price = 35;

        if (days < 10) {
            discount = 0.10;
        }
        else if (days >= 10 && days <= 15) {
            discount = 0.15;
        }
        else if (days > 15) {
            discount = 0.20;
        }
    }

    let holidayCost = (days * price) - (days * price * discount);

    if (evaluation === "positive") {
        holidayCost += holidayCost * 0.25;
    }
    else if (evaluation === "negative") {
        holidayCost -= holidayCost * 0.10;
    }

    console.log(holidayCost.toFixed(2));
}

skiTrip(["30", "president apartment", "negative"])

