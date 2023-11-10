function printSpecialWords (text) {
    let wordsArr = text.split(" ");
    let resultArr = [];
    let regex = /#[A-Za-z]+/gm;

    let matches = text.match(regex);

    for (let word of matches) {
        word = word.replace("#", "");
        console.log(word);
    }
}

printSpecialWords('The symbol # is known #variously in English-speaking #regions as the #number sign');