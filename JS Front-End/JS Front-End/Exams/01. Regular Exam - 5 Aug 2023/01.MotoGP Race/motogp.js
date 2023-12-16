function solveRace(input) {
    let [ridersCount, ...commands] = input;

    let ridersArr = getAllRiders();

    executeCommands(commands);

    ridersArr.forEach(r => {
        console.log(`${r.rider}\n  Final position: ${r.position}`);
    })


    function getAllRiders() {
        let allRiders = [];

        for (let i = 0; i < ridersCount; i++) {
            let currRiderInfo = commands.shift().split("|");

            let currRider = {
                rider: currRiderInfo[0],
                fuelCapacity: currRiderInfo[1],
                position: currRiderInfo[2],
            }

            allRiders.push(currRider);
        }

        return allRiders;
    }

    function executeCommands(commands) {
        while (true) {
            let commandTokens = commands.shift().split(" - ");
            let commandName = commandTokens[0];
            let riderName = commandTokens[1];

            if (commandName === "Finish") {
                break;
            }

            let rider = ridersArr.find(r => r.rider === riderName);

            if (commandName === "StopForFuel") {
                let minFuel = Number(commandTokens[2]);
                let changedPosition = Number(commandTokens[3]);

                if (rider.fuelCapacity < minFuel) {
                    rider.position = changedPosition
                    console.log(`${rider.rider} stopped to refuel but lost his position, now he is ${changedPosition}.`)
                } else {
                    console.log(`${rider.rider} does not need to stop for fuel!`);
                }

            } else if (commandName === "Overtaking") {
                let riderPosition = rider.position;

                let otherRacerName = commandTokens[2];
                let otherRider = ridersArr.find(r => r.rider === otherRacerName);
                let otherRiderPosition = otherRider.position;

                if (riderPosition < otherRiderPosition) {
                    rider.position = otherRiderPosition;
                    otherRider.position = riderPosition;

                    console.log(`${rider.rider} overtook ${otherRider.rider}!`);
                }


            } else if (commandName === "EngineFail") {
                let lapsLeft = Number(commandTokens[2]);
                let riderIdx = ridersArr.findIndex(r => r.rider === riderName);
                ridersArr.splice(riderIdx, 1);
                console.log(`${rider.rider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
            }
        }
    }
}

solveRace(["4",
    "Valentino Rossi|100|1",
    "Marc Marquez|90|3",
    "Jorge Lorenzo|80|4",
    "Johann Zarco|80|2",
    "StopForFuel - Johann Zarco - 90 - 5",
    "Overtaking - Marc Marquez - Jorge Lorenzo",
    "EngineFail - Marc Marquez - 10",
    "Finish"]);