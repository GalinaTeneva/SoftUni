function printElement (arr, step) {
    let newArr = [];

    for (let i = 0; i < arr.length; i += step) {
        newArr.push(arr[i]);
    }

    console.log(newArr.join("\n"));
}

printElement(['1', 
'2',
'3', 
'4', 
'5'], 
6)