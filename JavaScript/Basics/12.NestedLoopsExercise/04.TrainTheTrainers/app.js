'use strict';

function trainTheTrainers(input) {
    let juryCount = Number(input[0]);
    let idx = 1;
    let presentationsCounter = 0;
    let averagesSum = 0;

    while (input[idx] != "Finish") {
        let presentationName = input[idx++];
        presentationsCounter++;
        let gradesSum = 0;

        for (let i = 0; i < juryCount; i++) {
            let currGrade = Number(input[idx++]);
            gradesSum += currGrade;
        }

        let average = gradesSum / juryCount;
        averagesSum += average;
        console.log(`${presentationName} - ${average.toFixed(2)}.`);
    }

    let averageGrade = averagesSum / presentationsCounter;
    console.log(`Student's final assessment is ${averageGrade.toFixed(2)}.`);
}

trainTheTrainers(["3", "Arrays", "4.53", "5.23", "5.00", "Lists", "5.83", "6.00", "5.42", "Finish"]);


