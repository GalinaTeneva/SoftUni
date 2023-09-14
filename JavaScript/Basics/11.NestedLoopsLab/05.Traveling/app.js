'use strict';

function traveling(input) {
    let idx = 0;

    while (true) {
        let sum = 0;
        let destination = input[idx++];

        if (destination === "End") {
            break;
        }

        let targetSum = Number(input[idx++]);

        while (sum < targetSum) {
            let currSum = Number(input[idx]);
            sum += currSum;
            idx++;
        }

        console.log(`Going to ${destination}!`);
    }
}

traveling(["France", "2000", "300", "300", "200", "400", "190", "258", "360", "Portugal", "1450", "400", "400", "200", "300", "300", "Egypt", "1900", "1000", "280", "300", "500", "End"]);


