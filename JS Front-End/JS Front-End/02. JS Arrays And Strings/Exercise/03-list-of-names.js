function sortNames (arr) {
    arr = arr.sort((a, b) => {
        return a.localeCompare(b);
    });
    let result = "";

    for (let i = 1; i <= arr.length; i++) {
        result += `${i}.${arr[i - 1]}\n`;
    }

    console.log(result);
}

sortNames (["John", "Bob", "Christina", "Ema"])