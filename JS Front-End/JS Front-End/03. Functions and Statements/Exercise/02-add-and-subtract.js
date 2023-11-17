function calc (num1, num2, num3){

    let sumResult = sum(num1, num2);
    let subtractResult = subtract(sumResult, num3);

    console.log(subtractResult);

    function sum(firstNum, secondNum){
        return firstNum + secondNum;
    }
    function subtract(firstNum, secondNum){
        return firstNum - secondNum;
    }
}

calc(42,
    58,
    100);