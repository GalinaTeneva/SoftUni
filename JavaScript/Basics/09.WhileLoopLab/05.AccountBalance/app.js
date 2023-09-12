'use strict';

function accountBalance(input) {
    let idx = 0;
    let totalMoney = 0;

    while (input[idx] != "NoMoreMoney") {
        let currMoney = Number(input[idx]);

        if (currMoney < 0) {
            console.log("Invalid operation!");
            break;
        }
        else {
            console.log(`Increase: ${currMoney.toFixed(2)}`);
            totalMoney += currMoney;
        }

        idx++;
    }

    console.log(`Total: ${totalMoney.toFixed(2)}`);
}

accountBalance(["5.51", "69.42", "100", "NoMoreMoney"]);

