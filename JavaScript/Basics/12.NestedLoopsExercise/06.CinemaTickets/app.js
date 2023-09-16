'use strict';

function cinemaTickets(input) {
    let idx = 0;
    let totalStudentTickets = 0;
    let totalStandardTickets = 0;
    let totalKidTickets = 0;
    let totalSoldTickets = 0;
    let isFinish = false;

    while (true) {
        let movieName = input[idx++];

        if (movieName === "Finish") {
            break;
        }

        let seatsCount = Number(input[idx++]);

        let soldTickets = 0;

        for (let i = 0; i < seatsCount; i++) {
            if (input[idx] === "End") {
                idx++;
                break;
            }

            let ticketType = input[idx++];
            soldTickets++;

            switch (ticketType) {
                case "student":
                    totalStudentTickets++;
                    break;
                case "standard":
                    totalStandardTickets++;
                    break;
                case "kid":
                    totalKidTickets++;
                    break;

            }
        }

        let takenSeatsPercent = soldTickets / seatsCount * 100;
        console.log(`${movieName} - ${takenSeatsPercent.toFixed(2)}% full.`);
        totalSoldTickets += soldTickets;
    }

    let studentTicketsPersent = totalStudentTickets / totalSoldTickets * 100;
    let standardTicketsPersent = totalStandardTickets / totalSoldTickets * 100;
    let kidTicketsPersent = totalKidTickets / totalSoldTickets * 100;

    console.log(`Total tickets: ${totalSoldTickets}`);
    console.log(`${studentTicketsPersent.toFixed(2)}% student tickets.`);
    console.log(`${standardTicketsPersent.toFixed(2)}% standard tickets.`);
    console.log(`${kidTicketsPersent.toFixed(2)}% kids tickets.`);
}

cinemaTickets(["The Matrix", "20", "student", "standard", "kid", "kid", "student", "student", "standard", "student", "End", "The Green Mile", "17", "student", "standard", "standard", "student", "standard", "student", "End", "Amadeus", "3", "standard", "standard", "standard", "Finish"]);



