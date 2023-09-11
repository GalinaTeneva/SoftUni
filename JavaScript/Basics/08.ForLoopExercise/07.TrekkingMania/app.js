'use strict';

function trekkingMania(input) {
    let groupsCount = Number(input[0]);

    let totalPeople = 0;
    let musalaTourists = 0;
    let montblancTourists = 0;
    let kilimanjaroTourists = 0;
    let k2Tourists = 0;
    let everestTourists = 0;

    for (let i = 1; i <= groupsCount; i++) {
        let peopleCount = Number(input[i]);

        totalPeople += peopleCount;

        if (peopleCount <= 5) {
            musalaTourists += peopleCount;
        }
        else if (peopleCount >= 6 && peopleCount <= 12) {
            montblancTourists += peopleCount;
        }
        else if (peopleCount >= 13 && peopleCount <= 25) {
            kilimanjaroTourists += peopleCount;
        }
        else if (peopleCount >= 26 && peopleCount <= 40) {
            k2Tourists += peopleCount;
        }
        else if (peopleCount >= 41) {
            everestTourists += peopleCount;
        }
    }

    console.log(`${(musalaTourists / totalPeople * 100).toFixed(2)}%`);
    console.log(`${(montblancTourists / totalPeople * 100).toFixed(2)}%`);
    console.log(`${(kilimanjaroTourists / totalPeople * 100).toFixed(2)}%`);
    console.log(`${(k2Tourists / totalPeople * 100).toFixed(2)}%`);
    console.log(`${(everestTourists / totalPeople * 100).toFixed(2)}%`);
}

trekkingMania(["5", "25", "41", "31", "250", "6"]);


