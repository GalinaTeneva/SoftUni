function solve (number) {
    let numberAsString = String(number);
    let firstDigit = Number(numberAsString[0]);

    let sum = firstDigit;
    let areSameDigits = true;

    for (let i = 1; i < numberAsString.length; i++) {
        sum += Number(numberAsString[i]);

        if (areSameDigits) {
            if (Number(numberAsString[i]) !== firstDigit) {
                areSameDigits = false;
            }
        }
    }

    console.log(areSameDigits);
    console.log(sum)
}

solve(1234);