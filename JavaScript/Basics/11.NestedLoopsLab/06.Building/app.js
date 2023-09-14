'use strict';

function building(input) {
    let floorsCount = Number(input[0]);
    let roomsCount = Number(input[1]);

    for (let floor = floorsCount; floor >= 1; floor--) {
        let floorSign = "";

        if (floor % 2 === 0) {
            floorSign = "O";
        }
        else {
            floorSign = "A";
        }

        if (floor === floorsCount) {
            floorSign = "L";
        }

        let line = "";
        for (let room = 0; room < roomsCount; room++) {
            let currLine = `${floorSign}${floor}${room} `;
            line += currLine;
        }
            console.log(line);
    }
}

building(["6", "4"]);
