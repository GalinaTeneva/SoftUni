'use strict';

function suppliesForSchool(input) {

    const pricePerPensPackage = 5.80;
    const pricePerMarkersPackage = 7.20;
    const pricePerLiterCleaner = 1.20;

    let pensPackages = Number(input[0]);
    let markersPackages = Number(input[1]);
    let litersCleaner = Number(input[2]);
    let discountInPercent = Number(input[3]);

    let priceWitoutDiscount = (pensPackages * pricePerPensPackage) + (markersPackages * pricePerMarkersPackage) + (litersCleaner * pricePerLiterCleaner);
    let priceWithDiscount = priceWitoutDiscount - (priceWitoutDiscount * discountInPercent / 100);

    console.log(priceWithDiscount);
}

suppliesForSchool(["2 ", "3 ", "4 ", "25 "]);
