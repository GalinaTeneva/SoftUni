'use strict';

function passwordGuess(input){

    const phrase = "s3cr3t!P@ssw0rd";

    if (input[0] === phrase) {

        console.log("Welcome");
    }
    else {
        console.log("Wrong password!");
    }
}

passwordGuess(["s3cr3t!p@ss"]);
