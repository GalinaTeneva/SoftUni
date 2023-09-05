'use strict';

function operationsBetweenNumbers(input) {
    let firstNum = Number(input[0]);
    let secondNum = Number(input[1]);
    let operator = input[2];

    let result = 0

    if (secondNum === 0) {
        console.log(`Cannot divide ${firstNum} by zero`);
    }
    else if (operator === "+" || operator === "-" || operator === "*") {
        switch (operator) {
            case "+":
                result = firstNum + secondNum;
                break;
            case "-":
                result = firstNum - secondNum;
                break;
            case "*":
                result = firstNum * secondNum;
                break
        }

        let evenOrOdd;
        if (result % 2 === 0) {
            evenOrOdd = "even";
        }
        else {
            evenOrOdd = "odd";
        }

        console.log(`${firstNum} ${operator} ${secondNum} = ${result} - ${evenOrOdd}`);
    }
    else if (operator === "/") {
        result = firstNum / secondNum;

        console.log(`${firstNum} ${operator} ${secondNum} = ${result.toFixed(2)}`);
    }
    else if (operator === "%") {
        result = firstNum % secondNum;

        console.log(`${firstNum} ${operator} ${secondNum} = ${result}`);
    }
}

operationsBetweenNumbers(["123", "12", "/"]);

