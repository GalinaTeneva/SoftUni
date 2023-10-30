function findAndReplace(text, word) {
    let replaceString = "*".repeat(word.length);
    while (text.includes(word)) {
        text = text.replace(word, replaceString);
    }

    console.log(text);
}

findAndReplace('A small sentence with some words', 'small')