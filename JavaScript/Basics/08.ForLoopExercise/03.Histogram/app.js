'use strict';

function histogram(input) {
    let numbersCount = Number(input[0]);

    let p1Counter = 0;
    let p2Counter = 0;
    let p3Counter = 0;
    let p4Counter = 0;
    let p5Counter = 0;

    for (let i = 1; i <= numbersCount; i++) {
        let number = Number(input[i]);

        if (number < 200) {
            p1Counter++;
        }
        else if (number >= 200 && number < 400) {
            p2Counter++;
        }
        else if (number >= 400 && number < 600) {
            p3Counter++;
        }
        else if (number >= 600 && number < 800) {
            p4Counter++;
        }
        else if (number >= 800) {
            p5Counter++;
        }
    }

    console.log(`${(p1Counter / numbersCount * 100).toFixed(2)}%`);
    console.log(`${(p2Counter / numbersCount * 100).toFixed(2)}%`);
    console.log(`${(p3Counter / numbersCount * 100).toFixed(2)}%`);
    console.log(`${(p4Counter / numbersCount * 100).toFixed(2)}%`);
    console.log(`${(p5Counter / numbersCount * 100).toFixed(2)}%`);
}

histogram(["7", "800", "801", "250", "199", "399", "599", "799"]);

