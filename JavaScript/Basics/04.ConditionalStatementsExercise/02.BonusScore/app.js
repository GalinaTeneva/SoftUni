'use strict';

function bonusScore(input) {
    let number = Number(input[0]);

    let bonusPoints = 0;

    if (number <= 100) {
        bonusPoints += 5;
    }
    else if (number > 100) {
        if (number < 1000) {
            bonusPoints += number * 20 / 100;
        }
        else if (number > 1000) {
            bonusPoints += number * 10 / 100;
        }
    }

    if (number % 2 === 0) {
        bonusPoints++;
    }
    else if (number % 10 === 5) {
        bonusPoints += 2;
    }

    let totalPoints = number + bonusPoints;
    console.log(bonusPoints);
    console.log(totalPoints);
}

bonusScore(["15875"]);
