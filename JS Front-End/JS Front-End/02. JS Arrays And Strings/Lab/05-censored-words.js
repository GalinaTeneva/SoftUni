function findAndReplace(text, word) {
    let replaceString = "*".repeat(word.length);
    let editedText = text.replaceAll(word, replaceString);

    console.log(editedText);
}

findAndReplace('A small sentence with some words', 'small')