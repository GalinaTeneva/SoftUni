'use strict';

function fishingBoat(input) {
    let budget = Number(input[0]);
    let season = input[1];
    let fishermen = input[2];

    let boatRent = 0;
    let discount = 0;

    switch (season) {
        case "Spring":
            boatRent = 3000;
            break;
        case "Summer":
        case "Autumn":
            boatRent = 4200;
            break;
        case "Winter":
            boatRent = 2600;
            break;
    }
    
    if (fishermen <= 6) {
        discount = 0.1;
    }
    else if (fishermen >= 7 && fishermen <= 11) {
        discount = 0.15;
    }
    else if (fishermen >= 12) {
        discount = 0.25;
    }

    let totalCost = boatRent - (boatRent * discount);

    if (fishermen % 2 === 0 && season != "Autumn") {
        totalCost -= totalCost * 0.05;
    }

    if (budget >= totalCost) {
        let diff = budget - totalCost;
        console.log(`Yes! You have ${diff.toFixed(2)} leva left.`);
    }
    else {
        let diff = totalCost - budget;
        console.log(`Not enough money! You need ${diff.toFixed(2)} leva.`);
    }
}

fishingBoat(["3600", "Autumn", "6"]);

