function findOddOccurrences(input) {
    let allWordsOccurrences = {};
    let wordsWithOddOccurrences = {};

    let allWords = input.split(" ");

    allWords.forEach(w => {
        if (!allWordsOccurrences.hasOwnProperty(w.toLowerCase())) {
            allWordsOccurrences[w.toLowerCase()] = 1;
        } else {
            allWordsOccurrences[w.toLowerCase()] += 1;
        }
    })

    for (const element in allWordsOccurrences) {
        if (allWordsOccurrences[element] % 2 !== 0) {
            wordsWithOddOccurrences[element] = allWordsOccurrences[element];
        }
    }

    let entries = Object.entries(wordsWithOddOccurrences).sort((a, b) => b[1] - a[1]);
    let result = " ";

    for (const entry of entries) {
        result += entry[0] + " ";
    }

    console.log(result);
}

findOddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');