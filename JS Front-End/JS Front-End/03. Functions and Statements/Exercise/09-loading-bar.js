function printLoadBar(number){

    let loadingBar = generateLoadingBar(number);

    if(number === 100){
        console.log(`${number}% Complete!`);
        console.log(loadingBar);
    }else{
        console.log(`${number}% ${loadingBar}`);
        console.log(`Still loading...`);
    }

    function generateLoadingBar(number){
        let repeatsCount = number / 10;
        let firstRepeat = "%".repeat(repeatsCount);
        let secondRepeat = ".".repeat(10 - repeatsCount);
        return `[${firstRepeat}${secondRepeat}]`; 
    }
}

printLoadBar(50);