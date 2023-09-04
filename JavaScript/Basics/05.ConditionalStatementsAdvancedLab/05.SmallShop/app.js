'use strict';

function smallShop(input) {
    let drink = input[0];
    let town = input[1];
    let quantity = Number(input[2]);

    let price = 0;
    if (drink === "coffee") {
        if (town === "Sofia") {
            price = 0.50;
        }
        else if (town === "Plovdiv") {
            price = 0.40;
        }
        else if (town === "Varna") {
            price = 0.45;
        }
    }
    else if (drink === "water") {
        if (town === "Sofia") {
            price = 0.80;
        }
        else if (town === "Plovdiv") {
            price = 0.70;
        }
        else if (town === "Varna") {
            price = 0.70;
        }
    }
    else if (drink === "beer") {
        if (town === "Sofia") {
            price = 1.20;
        }
        else if (town === "Plovdiv") {
            price = 1.15;
        }
        else if (town === "Varna") {
            price = 1.10;
        }
    }
    else if (drink === "sweets") {
        if (town === "Sofia") {
            price = 1.45;
        }
        else if (town === "Plovdiv") {
            price = 1.30;
        }
        else if (town === "Varna") {
            price = 1.35;
        }
    }
    else if (drink === "peanuts") {
        if (town === "Sofia") {
            price = 1.60;
        }
        else if (town === "Plovdiv") {
            price = 1.50;
        }
        else if (town === "Varna") {
            price = 1.55;
        }
    }

    let total = quantity * price;
    console.log(total);
}

smallShop(["peanuts", "Plovdiv", "1"])

