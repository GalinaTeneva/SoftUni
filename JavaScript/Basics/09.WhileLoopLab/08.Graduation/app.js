'use strict';

function graduation(input) {
    let name = input[0];

    let failuresCounter = 0;
    let grade = 1;
    let gradesSum = 0;

    while (grade < 13) {
        let currGrade = Number(input[grade]);

        if (currGrade < 4.00) {
            failuresCounter++;
        }
        if (failuresCounter === 2) {
            console.log(`${name} has been excluded at ${grade - 1} grade`);
            break;
        }

        gradesSum += currGrade;
        grade++;
    }

    let averaageGrade = gradesSum / 12;

    if (failuresCounter != 2) {
        console.log(`${name} graduated. Average grade: ${averaageGrade.toFixed(2)}`);
    }
}

graduation(["Gosho", "5", "5.5", "6", "5.43", "5.5", "6", "5.55", "5", "6", "6", "5.43", "5"]);
