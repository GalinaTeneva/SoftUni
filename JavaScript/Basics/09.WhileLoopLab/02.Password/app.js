'use strict';

function password(input) {
    let username = input[0];
    let pass = input[1];

    let idx = 2;

    while (true) {
        if (input[idx] === pass) {
            console.log(`Welcome ${username}!`);
            break;
        }

        idx++;
    }
}

password(["Nakov", "1234", "Pass", "1324", "1234"]);

