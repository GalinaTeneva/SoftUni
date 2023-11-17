function sumDigits(number){
    let numAsString = number.toString();

    let evenSum = 0;
    let oddSum = 0;

    for(let i = 0; i < numAsString.length; i++){
        let currDigit = Number(numAsString[i]);

        if(currDigit % 2 === 0){
            evenSum += currDigit;
        } else {
            oddSum += currDigit;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

sumDigits(3495892137259234);