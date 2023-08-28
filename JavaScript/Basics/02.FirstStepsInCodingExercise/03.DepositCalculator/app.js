'use strict';

function depositCalculator(input) {

    let depositAmount = Number(input[0]);
    let depositDuration = Number(input[1]);
    let annualInterestRate = Number(input[2]) / 100;

    let finalAmount = depositAmount + (depositDuration * ((depositAmount * annualInterestRate) / 12));
    console.log(finalAmount);
}

depositCalculator(["200 ", "3 ", "5.7 "]
)
