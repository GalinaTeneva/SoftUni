'use strict';

function salary(input) {
    const FACEBOOK_FINE = 150;
    const INSTAGRAM_FINE = 100;
    const REDDIT_FINE = 50;

    let tabsCount = Number(input[0]);
    let salary = Number(input[1]);

    for (let i = 2; i < tabsCount + 2; i++) {
        let websiteName = input[i];

        if (websiteName === "Facebook") {
            salary -= FACEBOOK_FINE;
        }
        else if (websiteName === "Instagram") {
            salary -= INSTAGRAM_FINE;
        }
        else if (websiteName === "Reddit") {
            salary -= REDDIT_FINE;
        }

        if (salary <= 0) {
            console.log("You have lost your salary.");
            break;
        }
    }

    if (salary > 0) {
        console.log(salary);
    }
}

salary(["3", "500", "Github.com", "Stackoverflow.com", "softuni.bg"]);


