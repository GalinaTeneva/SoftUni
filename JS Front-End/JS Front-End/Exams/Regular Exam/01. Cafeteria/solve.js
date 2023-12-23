function solveCafeteria (input) {
    let [baristasCount, ...commands] = input;

    let baristasArr = getAllBaristas();

    executeCommands(commands);

    baristasArr.forEach(b => {
        let drinksList = b.coffeeTypes.join(", ");
        console.log(`Barista: ${b.name}, Shift: ${b.shift}, Drinks: ${drinksList}`);
    })
    
    function getAllBaristas() {
        let allBaristas = [];

        for (let i = 0; i < baristasCount; i++) {
            let currBaristaInfo = commands.shift().split(" ");
            let coffeeTypesArr = currBaristaInfo[2].split(",");

            let currBarista = {
                name: currBaristaInfo[0],
                shift: currBaristaInfo[1],
                coffeeTypes: coffeeTypesArr
            }

            allBaristas.push(currBarista);
        }

        return allBaristas;
    }

    function executeCommands (commands) {
        while (true) {
            let currCommandTokens = commands.shift().split(" / ");
            let commandName = currCommandTokens[0];
            let baristaName = currCommandTokens[1];

            if(commandName === "Closed") {
                break;
            }

            let barista = baristasArr.find(b => b.name === baristaName);

            if (commandName === "Prepare") {
                let shift = currCommandTokens[2];
                let coffeeType = currCommandTokens[3];

                if (barista.shift === shift && barista.coffeeTypes.includes(coffeeType)) {
                    
                    console.log(`${barista.name} has prepared a ${coffeeType} for you!`);
                } else {
                    console.log(`${barista.name} is not available to prepare a ${coffeeType}.`);
                }

            } else if (commandName === "Change Shift") {
                let newShift = currCommandTokens[2];
                barista.shift = newShift;

                console.log(`${barista.name} has updated his shift to: ${newShift}`);

            } else if (commandName === "Learn") {
                let newCoffeeType = currCommandTokens[2];
                if(barista.coffeeTypes.includes(newCoffeeType)) {
                    console.log(`${barista.name} knows how to make ${newCoffeeType}.`)

                } else {
                    barista.coffeeTypes.push(newCoffeeType);
                    console.log(`${barista.name} has learned a new coffee type: ${newCoffeeType}.`);
                }
            }
        }
    }
}

solveCafeteria(['4',
'Alice day Espresso,Cappuccino',
'Bob night Latte,Mocha',
'Carol day Americano,Mocha',
'David night Espresso',
'Prepare / Alice / day / Espresso',
'Change Shift / Bob / day',
'Learn / Carol / Latte',
'Prepare / Bob / night / Latte',
'Learn / David / Cappuccino',
'Prepare / Carol / day / Cappuccino',
'Change Shift / Alice / night',
 'Learn / Bob / Mocha',
'Prepare / David / night / Espresso',
'Closed']);