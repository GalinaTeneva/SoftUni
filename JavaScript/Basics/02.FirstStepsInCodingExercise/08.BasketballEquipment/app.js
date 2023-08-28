'use strict';

function basketballEquipment(input) {

    let annualFee = Number(input[0]);

    let sneakersCost = annualFee - (annualFee * 0.4);
    let clothesCost = sneakersCost - (sneakersCost * 0.20);
    let ballCost = clothesCost / 4;
    let accessoriesCost = ballCost / 5;

    let totalCosts = annualFee + sneakersCost + clothesCost + ballCost + accessoriesCost;
    console.log(totalCosts);
}

basketballEquipment(["365 "])
