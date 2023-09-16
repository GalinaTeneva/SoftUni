'use strict';

function sumPrimeNonPrime(input) {
    let primeNumsSum = 0;
    let nonPrimeNumsSum = 0;
    let idx = 0;

    while (input[idx] != "stop") {
        let currNumber = Number(input[idx]);

        if (currNumber < 0) {
            console.log("Number is negative.");
            idx++;
            continue;
        }

        let isPrime = true;

        for (let i = 2; i < currNumber; i++) {
            if (currNumber % i === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime) {
            primeNumsSum += currNumber;
        }
        else {
            nonPrimeNumsSum += currNumber;
        }

        idx++;
    }

    console.log(`Sum of all prime numbers is: ${primeNumsSum}`);
    console.log(`Sum of all non prime numbers is: ${nonPrimeNumsSum}`);
}

sumPrimeNonPrime(["30", "83", "33", "-1", "20", "stop"]);


