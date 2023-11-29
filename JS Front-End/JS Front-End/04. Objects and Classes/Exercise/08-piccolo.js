function solvePiccolo(input){
    let parkedCars = [];

    for(let i = 0; i < input.length; i++){
        let [cmd, carNumber] = input[i].split(", ");

        if (cmd === "IN" && !parkedCars.includes(carNumber)){
            parkedCars.push(carNumber);
        } else if (cmd === "OUT" && parkedCars.includes(carNumber)){
            let idx = parkedCars.indexOf(carNumber);
            parkedCars.splice(idx, 1);
        }
    }

    if (parkedCars.length === 0){
        console.log("Parking Lot is Empty");
    } else {
        let sortedCars = parkedCars.sort();

        for (const car of sortedCars) {
            console.log(car);
        }
    }
}

solvePiccolo(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
);