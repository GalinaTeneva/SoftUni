function palindromeCheck(numsArr){

    for (const number of numsArr) {
        let numAsString = number.toString();
        let currNumCharsArr = numAsString.split("");
        let reverseNumAsString = currNumCharsArr.reverse().join("");

        if(number === Number(reverseNumAsString)){
            console.log("true");
        } else {
            console.log("false");
        }
    }
}

palindromeCheck([32,2,232,1010]);