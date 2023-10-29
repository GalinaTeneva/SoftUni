function cookNumber (num, operation1, operation2, operation3, operation4, operation5,) {
    let number = Number(num);

    const opsArr = [operation1, operation2, operation3, operation4, operation5];

    for (let index = 0; index < opsArr.length; index++) {
        let currOperation = opsArr[index];

        switch (currOperation) {
            case "chop": number /= 2; break;
            case "dice": number = Math.sqrt(number); break;
            case "spice": number++; break;
            case "bake": number *= 3; break;
            case "fillet": number -= (number * 0.2); break;
        }
        console.log(number);
    }
}

cookNumber ('32', 'chop', 'chop', 'chop', 'chop', 'chop')