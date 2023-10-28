function calcSum(numOne, numTwo) {
    let numsString = "";
    let sum = 0;

    for (let i = numOne; i <= numTwo; i++) {
        numsString = `${numsString} ${i}`;
        sum += i;
    }

    console.log(numsString);
    console.log(`Sum: ${sum}`);
}

calcSum (50, 60);