function revealWords (wordsString, template) {
    let templateLength = template.length;

    let wordsArr = wordsString.split(", ");
    let templateArr = template.split(" ");

    for (let i = 0; i < wordsArr.length; i++) {
        for (let j = 0; j < templateArr.length; j++) {
            if (templateArr[j].includes('*') && templateArr[j].length === wordsArr[i].length) {
                templateArr[j] = wordsArr[i];
            }
        }
    }

    console.log(templateArr.join(" "));
}

revealWords('great, learning',
'softuni is ***** place for ******** new programming languages'
);