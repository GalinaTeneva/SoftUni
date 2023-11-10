function rotate (arr, count) {
    for (let i = 1; i <= count; i++) {
        let currElement = arr.shift();
        arr.push(currElement);
    }

    console.log(arr.join(" "));
}

rotate([2, 4, 15, 31], 5)