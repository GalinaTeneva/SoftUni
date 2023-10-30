function makeSubstring (string, startIdx, count) {
    let result = string.substring(startIdx, startIdx + count);

    console.log(result);
}

makeSubstring('ASentence', 1, 8);