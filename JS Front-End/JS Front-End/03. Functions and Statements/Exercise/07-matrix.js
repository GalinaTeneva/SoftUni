function printMatrix(number){
    let line = (number.toString() + " ").repeat(number);

    for (let i = 0; i < number; i++){
        console.log(line);
    }
}

printMatrix(3);