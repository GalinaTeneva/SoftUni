'use strict';

function repainting(input) {

    const protectiveCoverPricePerSquareMeter = 1.50;
    const paintPricePerLiter = 14.50;
    const thinnerPricePerLiter = 5;

    const paintAdditionalQuantityInPercent = 10;
    const workercFeeInPercent = 30;
    const protectiveCoverAdditionalQuantity = 2;
    const bagsPrice = 0.40;

    let neededProtectiveCover = Number(input[0]);
    let neededPaint = Number(input[1]);
    let neededPaintThinner = Number(input[2]);
    let workingHours = Number(input[3]);

    let amountForProtectiveCover = (neededProtectiveCover + protectiveCoverAdditionalQuantity) * protectiveCoverPricePerSquareMeter;
    let amountForPaint = (neededPaint + (neededPaint * paintAdditionalQuantityInPercent / 100)) * paintPricePerLiter;
    let amountForPaintThinner = neededPaintThinner * thinnerPricePerLiter;

    let totalAmountForSupplies = amountForProtectiveCover + amountForPaint + amountForPaintThinner + bagsPrice;

    let amountForWorkers = (totalAmountForSupplies * workercFeeInPercent / 100) * workingHours;
    let finalAmount = totalAmountForSupplies + amountForWorkers;

    console.log(finalAmount);
}

repainting(["10 ", "11 ", "4 ", "8 "]);
