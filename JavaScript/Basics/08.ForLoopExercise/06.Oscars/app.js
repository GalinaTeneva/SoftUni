'use strict';

function oscars(input) {
    let name = input[0];
    let actorPoints = Number(input[1]);
    let accessorsCount = Number(input[2]);

    for (let i = 3; i <= (accessorsCount * 2) + 2; i += 2) {
        let currAccessor = input[i];
        let currAccessorPoints = input[i + 1];
        let currPoints = currAccessor.length * currAccessorPoints / 2;
        actorPoints += currPoints;

        if (actorPoints > 1250.50) {
            break;
        }
    }

    if (actorPoints < 1250.50) {
        let diff = 1250.50 - actorPoints;
        console.log(`Sorry, ${name} you need ${diff.toFixed(1)} more!`);
    }
    else {
        console.log(`Congratulations, ${name} got a nominee for leading role with ${actorPoints.toFixed(1)}!`);
    }
}

oscars(["Sandra Bullock", "340", "5", "Robert De Niro", "50", "Julia Roberts", "40.5", "Daniel Day-Lewis", "39.4", "Nicolas Cage", "29.9", "Stoyanka Mutafova", "33"]);


