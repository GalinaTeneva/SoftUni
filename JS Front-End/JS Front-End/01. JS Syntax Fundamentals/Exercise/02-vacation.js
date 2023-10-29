function vacationCost (peopleNum, groupType, dayOfWeek) {
    let ticketPrice = 0;
    let discount = 0;

    if (groupType === "Students"){
        if(dayOfWeek === "Friday"){
            ticketPrice = 8.45;
        }
        else if (dayOfWeek === "Saturday"){
            ticketPrice = 9.80;
        }
        else if (dayOfWeek === "Sunday"){
            ticketPrice = 10.46;
        }

        if (peopleNum >= 30) {
            discount = 0.15;
        }
    }
    else if (groupType === "Business") {
        if(dayOfWeek === "Friday"){
            ticketPrice = 10.90;
        }
        else if (dayOfWeek === "Saturday"){
            ticketPrice = 15.60;
        }
        else if (dayOfWeek === "Sunday"){
            ticketPrice = 16;
        }

        if (peopleNum >= 100) {
            peopleNum -= 10;
        }
    }
    else if (groupType === "Regular") {
        if(dayOfWeek === "Friday"){
            ticketPrice = 15;
        }
        else if (dayOfWeek === "Saturday"){
            ticketPrice = 20;
        }
        else if (dayOfWeek === "Sunday"){
            ticketPrice = 22.50;
        }

        if (peopleNum >= 10 && peopleNum <= 20) {
            discount = 0.05;
        }
    }

    let totalPrice = peopleNum * ticketPrice;
    let finalPrice = totalPrice - totalPrice * discount;

    console.log(`Total price: ${finalPrice.toFixed(2)}`);
}

vacationCost(40,
    "Regular",
    "Saturday"
    );