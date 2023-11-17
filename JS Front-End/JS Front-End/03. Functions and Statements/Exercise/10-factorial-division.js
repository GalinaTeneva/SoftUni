function solve(num1, num2){
    function calcFactorial(number){
        let factorial = 1;
        for(let i = 1; i <= number; i++){
            factorial *= i;
        }

        return factorial;
    }

    let result = calcFactorial(num1) / calcFactorial(num2);
    console.log(result.toFixed(2));
}

solve(5,
    2);