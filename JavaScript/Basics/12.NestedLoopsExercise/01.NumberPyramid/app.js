'use strict';

function numberPyramid(input){
    let num = Number(input);

    let currNum = 1;
    let isBigger = false;

    for (let i = 1; i <= num; i++) {
        let currLine = "";

        for (let j = 1; j <= i; j++) {
            if (currNum > num) {
                isBigger = true;
                break;
            }

            currLine = currLine + currNum + " ";
            currNum++;
        }

        console.log(currLine);

        if (isBigger) {
            break;
        }
    }
}

numberPyramid(["15"]);
