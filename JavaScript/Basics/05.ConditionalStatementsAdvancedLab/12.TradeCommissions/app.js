'use strict';

function tradeCommissions(input) {
    let town = input[0];
    let sells = Number(input[1]);

    let commissionPercent = 0;
    if (town === "Sofia") {
        if (sells >= 0 && sells <= 500) {
            commissionPercent = 5;
        }
        else if (sells > 500 && sells <= 1000) {
            commissionPercent = 7;
        }
        else if (sells > 1000 && sells <= 10000) {
            commissionPercent = 8;
        }
        else if (sells > 10000) {
            commissionPercent = 12;
        }
        else {
            console.log("error");
        }
    }
    else if (town === "Varna") {
        if (sells >= 0 && sells <= 500) {
            commissionPercent = 4.5;
        }
        else if (sells > 500 && sells <= 1000) {
            commissionPercent = 7.5;
        }
        else if (sells > 1000 && sells <= 10000) {
            commissionPercent = 10;
        }
        else if (sells > 10000) {
            commissionPercent = 13;
        }
        else {
            console.log("error");
        }
    }
    else if (town === "Plovdiv") {
        if (sells >= 0 && sells <= 500) {
            commissionPercent = 5.5;
        }
        else if (sells > 500 && sells <= 1000) {
            commissionPercent = 8;
        }
        else if (sells > 1000 && sells <= 10000) {
            commissionPercent = 12;
        }
        else if (sells > 10000) {
            commissionPercent = 14.5;
        }
        else {
            console.log("error");
        }
    }
    else {
        console.log("error");
    }

    if (commissionPercent > 0) {
        let commissionValue = sells * commissionPercent / 100;
        console.log(commissionValue.toFixed(2));
    }
}

tradeCommissions(["Varna",
    "3874.50"])

