function reverseArr(num, arr) {
    let newArrLength = Number(num);
    let newArr = [];

    for(let i = newArrLength - 1; i >= 0; i--) {
        newArr.push(arr[i]);
    }

    let result = "";

    for(let i = 0; i < newArrLength; i++) {
        result += newArr[i] + " ";
    }

    console.log(result);
}

reverseArr(4, [-1, 20, 99, 5]);