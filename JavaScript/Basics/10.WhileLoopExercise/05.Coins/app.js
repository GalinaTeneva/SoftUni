'use strict';

function coins(input) {
    let change = Number(input[0]);

    let coinsCounter = 0;

    while (change >= 2) {
        change = (change - 2).toFixed(2);
        coinsCounter++;
    }
    while (change >= 1) {
        change = (change - 1).toFixed(2);
        coinsCounter++;
    }
    while (change >= 0.50) {
        change = (change - 0.50).toFixed(2);
        coinsCounter++;
    }
    while (change >= 0.20) {
        change = (change - 0.20).toFixed(2);
        coinsCounter++;
    }
    while (change >= 0.10) {
        change = (change - 0.10).toFixed(2)
        coinsCounter++;
    }
    while (change >= 0.05) {
        change = (change - 0.05).toFixed(2)
        coinsCounter++;
    }
    while (change >= 0.02) {
        change = (change - 0.02).toFixed(2)
        coinsCounter++;
    }
    while (change >= 0.01) {
        change = (change - 0.01).toFixed(2)
        coinsCounter++;
    }

    console.log(coinsCounter);
}

coins(["0.56"]);
