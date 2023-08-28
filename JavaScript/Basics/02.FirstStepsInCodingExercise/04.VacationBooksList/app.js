'use strict';

function booksList(input) {

    let bookPages = Number(input[0]);
    let pagesPerHour = Number(input[1]);
    let days = Number(input[2]);

    let readingPerDayInHours = bookPages / pagesPerHour / days;

    console.log(readingPerDayInHours);
}

booksList(["212 ", "20 ", "2 "]);
