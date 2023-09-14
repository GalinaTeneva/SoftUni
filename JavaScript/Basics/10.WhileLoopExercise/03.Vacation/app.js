'use strict';

function vacation(input) {
    let neededMoney = Number(input[0]);
    let availableMoney = Number(input[1]);

    let idx = 2;
    let spendingCounter = 0;
    let totalDays = 0;

    while (true) {
        let cmd = input[idx++];
        let amount = Number(input[idx]);

        totalDays++;

        if (cmd === "spend") {
            spendingCounter++;
            availableMoney -= amount;

            if (availableMoney < 0) {
                availableMoney = 0;
            }

            if (spendingCounter === 5) {
                console.log("You can't save the money.");
                console.log(totalDays);
                break;
            }
        }
        else if (cmd === "save") {
            availableMoney += amount;
            spendingCounter = 0;

            if (availableMoney >= neededMoney) {
                console.log(`You saved the money for ${totalDays} days.`);
                break;
            }
        }

        idx++;
    }
}

vacation(["250", "150", "spend", "50", "spend", "50", "save", "100", "save", "100"]);
