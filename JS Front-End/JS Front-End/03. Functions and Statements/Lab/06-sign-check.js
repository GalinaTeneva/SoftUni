function checkSign(numOne, numTwo, numThree){
    let result = numOne * numTwo * numThree;

    if(result >= 0){
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}

checkSign(-6,
    -12,
     14);