'use strict';

function cleverLily(input) {
    const BDAY_CASH_INCREASE = 10;
    const BROTHER_FEE = 1;

    let age = Number(input[0]);
    let washingMachinePrice = Number(input[1]);
    let toyPrice = Number(input[2]);

    let currBDayMoney = 0;
    let toyCounter = 0;
    let totalMoney = 0;
    for (let i = 1; i <= age; i++) {
        if (i % 2 === 0) {
            currBDayMoney += BDAY_CASH_INCREASE;
            totalMoney += currBDayMoney;
            totalMoney -= BROTHER_FEE;
        }
        else {
            toyCounter++;
        }
    }

    let toysMoney = toyCounter * toyPrice;
    totalMoney += toysMoney;

    if (totalMoney >= washingMachinePrice) {
        let diff = totalMoney - washingMachinePrice;
        console.log(`Yes! ${diff.toFixed(2)}`)
    }
    else {
        let diff = washingMachinePrice - totalMoney;
        console.log(`No! ${diff.toFixed(2)}`)
    }
}

cleverLily(["21", "1570.98", "3"]);


