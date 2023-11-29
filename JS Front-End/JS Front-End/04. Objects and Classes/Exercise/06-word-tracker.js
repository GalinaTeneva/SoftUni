function trackWords(input){
    let wordsToFind = input.shift().split(" ");

    let foundWords = {};

    wordsToFind.forEach(w => {
        foundWords[w] = 0;

        input.forEach(el => {
            if (w === el) {
                foundWords[w] += 1;
            }
        });
    });

    let entries = Object.entries(foundWords).sort((a, b) => b[1] - a[1]);

    for (const [key, value] of entries) {
        console.log(`${key} - ${value}`);
    }
}

trackWords([
    'is the', 
    'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence']
    );