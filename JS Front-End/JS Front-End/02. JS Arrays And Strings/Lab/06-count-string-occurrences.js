function wordCounter (text, word) {
    let words = text.split(" ");
    let counter = 0;

    for (let index = 0; index < words.length; index++) {
        let currWord = words[index];

        if (currWord === word) {
            counter++;
        }
    }

    console.log (counter);
}

wordCounter('softuni is great place for learning new programming languages',
'softuni');