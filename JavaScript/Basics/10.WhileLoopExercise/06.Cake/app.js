'use strict';

function cake(input) {
    let width = Number(input[0]);
    let length = Number(input[1]);

    let pieces = width * length;

    let idx = 2;

    while (input[idx] != "STOP") {
        let curr = Number(input[idx]);

        pieces -= curr;

        if (pieces < 0) {
            console.log(`No more cake left! You need ${Math.abs(pieces)} pieces more.`);
            break;
        }

        idx++;
    }

    if (pieces > 0) {
        console.log(`${pieces} pieces are left.`);
    }
}

cake(["10", "2", "2", "4", "6", "STOP"]);


