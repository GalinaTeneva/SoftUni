'use strict';

function hotelRoom(input) {
    let month = input[0];
    let stays = Number(input[1]);

    let studioPrice = 0;
    let apartmentPrice = 0;

    if (month === "May" || month === "October") {
        studioPrice = 50;
        apartmentPrice = 65;

        if (stays > 7 && stays <= 14) {
            studioPrice -= studioPrice * 0.05;
        }
        else if (stays > 14) {
            studioPrice -= studioPrice * 0.30;
            apartmentPrice -= apartmentPrice * 0.10;
        }
    }
    else if (month === "June" || month === "September") {
        studioPrice = 75.20;
        apartmentPrice = 68.70;

        if (stays > 14) {
            studioPrice -= studioPrice * 0.20;
            apartmentPrice -= apartmentPrice * 0.10;
        }
    }
    else if (month === "July" || month === "August") {
        studioPrice = 76;
        apartmentPrice = 77;

        if (stays > 14) {
            apartmentPrice -= apartmentPrice * 0.10;
        }
    }

    let totalStudioCost = stays * studioPrice;
    let totalApartmentCost = stays * apartmentPrice;

    console.log(`Apartment: ${totalApartmentCost.toFixed(2)} lv.`);
    console.log(`Studio: ${totalStudioCost.toFixed(2)} lv.`);
}

hotelRoom(["May", "15"]);

