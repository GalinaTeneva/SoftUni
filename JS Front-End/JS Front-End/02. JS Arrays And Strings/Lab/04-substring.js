function makeSubstring (string, startIdx, count) {
    let result = "";

    for (let index = startIdx; index <= count; index++) {
        result += string[index];
    }

    console.log(result);
}

makeSubstring('ASentence', 1, 8);