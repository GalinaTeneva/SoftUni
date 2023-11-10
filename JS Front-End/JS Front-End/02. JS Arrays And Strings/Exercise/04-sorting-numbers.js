function sortNumbers (arr) {
    let sortedArr = arr.sort((a, b) => a - b);
    let newArr = [];
    let arrLength = arr.length;

    for (let i = 0; i < arrLength; i++) {
        if (i % 2 === 0) {
            newArr.push(sortedArr.shift());
        }else {
            newArr.push(sortedArr.pop());
        }
    }

    return newArr;
}

sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);