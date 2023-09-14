'use strict';

function oldBooks(input) {
    let searchedBook = input[0];
    let idx = 1;
    let booksCounter = 0;
    let isFound = false;

    while (input[idx] != "No More Books") {
        let book = input[idx];

        if (book === searchedBook) {
            isFound = true;
            break;
        }

        booksCounter++;
        idx++;
    }

    if (isFound) {
        console.log(`You checked ${booksCounter} books and found it.`);
    }
    else {
        console.log("The book you search is not here!");
        console.log(`You checked ${booksCounter} books.`);
    }
}

oldBooks(["Troy", "Stronger", "Life Style", "Troy"]);
