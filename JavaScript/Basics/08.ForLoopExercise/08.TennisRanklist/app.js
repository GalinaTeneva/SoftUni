'use strict';

function tennisRanklist(input) {
    let tournamentsCount = Number(input[0]);
    let totalPoints = Number(input[1]);

    let tournamentsPoints = 0
    let wins = 0;

    for (let i = 2; i <= tournamentsCount + 2; i++) {
        let tournamentStage = input[i];

        switch (tournamentStage) {
            case "W":
                totalPoints += 2000;
                tournamentsPoints += 2000;
                wins++;
                break;
            case "F":
                totalPoints += 1200;
                tournamentsPoints += 1200;
                break;
            case "SF":
                totalPoints += 720;
                tournamentsPoints += 720;
                break;
        }
    }

    let averagePoints = Math.floor(tournamentsPoints / tournamentsCount);
    let winsPercent = wins / tournamentsCount * 100;
    console.log(`Final points: ${totalPoints}`);
    console.log(`Average points: ${averagePoints}`);
    console.log(`${winsPercent.toFixed(2)}%`);
}

tennisRanklist(["4", "750", "SF", "W", "SF", "W"]);


