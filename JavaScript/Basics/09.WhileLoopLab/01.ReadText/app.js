'use strict';

function readText(input) {
    let idx = 0;

    while (true) {
        if (input[idx] === "Stop") {
            break;
        }

        console.log(input[idx]);
        idx++;
    }
}

readText(["Nakov", "SoftUni", "Sofia", "Bulgaria", "SomeText", "Stop", "AfterStop", "Europe", "HelloWorld"]);

