'use strict';

function examPreparation(input) {
    let maxPoorGrades = Number(input[0]);

    let idx = 1;
    let poorGradesCounter = 0;
    let problemsCounter = 0;
    let gradesSum = 0;
    let problemName = "";

    while (input[idx] != "Enough") {
        problemName = input[idx++];
        let currGrade = Number(input[idx]);

        if (currGrade <= 4) {
            poorGradesCounter++;
        }
        if (poorGradesCounter === maxPoorGrades) {
            break;
        }

        problemsCounter++;
        gradesSum += currGrade;
        idx ++;
    }

    if (poorGradesCounter === maxPoorGrades) {
        console.log(`You need a break, ${maxPoorGrades} poor grades.`);
    }
    else {
        let averageGrade = gradesSum / problemsCounter;

        console.log(`Average score: ${averageGrade.toFixed(2)}`);
        console.log(`Number of problems: ${problemsCounter}`);
        console.log(`Last problem: ${problemName}`);
    }
}

examPreparation(["2", "Income", "3", "Game Info", "6", "Best Player", "4"]);

