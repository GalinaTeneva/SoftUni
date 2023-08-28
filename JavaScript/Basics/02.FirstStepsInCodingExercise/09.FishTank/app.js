'use strict';

function fishTank(input){

    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let percent = Number(input[3]);

    let volumeInSm = length * width * height;
    let volumeInLiters = volumeInSm / 1000;
    let neededLiters = volumeInLiters * (1 - percent / 100);

    console.log(neededLiters);
}

fishTank(["85 ", "75 ", "47 ", "17 "])
