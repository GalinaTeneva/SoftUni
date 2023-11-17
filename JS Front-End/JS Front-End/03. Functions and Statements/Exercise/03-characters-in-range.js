function printCharacters(char1, char2){
    let firstCharCode = char1.charCodeAt(0);
    let secondCharCode = char2.charCodeAt(0);

    let startChar = Math.min(firstCharCode, secondCharCode);
    let endChar = Math.max(firstCharCode, secondCharCode);

    let charsArr = [];

    for (let i = startChar + 1; i < endChar; i++){
        let currChar = String.fromCharCode(i);
        charsArr.push(currChar);
    }

    console.log(charsArr.join(" "));
}

printCharacters('C', '#');