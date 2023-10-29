function calcDifference(input) {
    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < input.length; i++) {
        let currNum = input[i];

        if (currNum % 2 === 0) {
            evenSum += currNum;
        } else {
            oddSum += currNum;
        }
    }

    console.log(evenSum - oddSum);
}

calcDifference([2,4,6,8,10]);