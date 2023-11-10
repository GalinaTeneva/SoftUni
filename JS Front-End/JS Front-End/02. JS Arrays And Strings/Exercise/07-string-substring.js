function wordCheck(word, text) {
    let textArr = text.split(" ");
    let uppercaseWord = word.toUpperCase();
    let isFound = false;

    for (const currWord of textArr) {
        if (currWord.toUpperCase() === uppercaseWord) {
            console.log(word);
            isFound = true;
            break;
        }
    }

    if (!isFound) {
        console.log(`${word} not found!`)
    }
}

wordCheck ('python',
'JavaScript is the best programming language');