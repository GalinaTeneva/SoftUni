'use strict';

function journey(input) {
    let budget = Number(input[0]);
    let season = input[1];

    let holidayType;
    let destination;
    let tripCost = 0;

    if (budget <= 100) {
        destination = "Bulgaria";
        switch (season) {
            case "summer":
                holidayType = "Camp";
                tripCost = budget * 0.30;
                break;
            case "winter":
                holidayType = "Hotel";
                tripCost = budget * 0.70;
                break;
        }
    }
    else if (budget > 100 && budget <= 1000) {
        destination = "Balkans";
        switch (season) {
            case "summer":
                holidayType = "Camp";
                tripCost = budget * 0.40;
                break;
            case "winter":
                holidayType = "Hotel";
                tripCost = budget * 0.80;
                break;
        }
    }
    else if (budget > 1000) {
        destination = "Europe";
        holidayType = "Hotel"
        tripCost = budget * 0.90;
    }

    console.log(`Somewhere in ${destination}`);
    console.log(`${holidayType} - ${tripCost.toFixed(2)}`);
}

journey(["50", "summer"])
