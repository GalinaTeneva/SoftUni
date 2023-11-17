function passwordValidation(password){

    function validateLength (word){
        return word.length >= 6 && word.length <= 10;
    }

    function ValidateSymbols (word){
        const regex = new RegExp('^[A-Za-z0-9]+$');
        let result = regex.test(word);
        return result;
    }

    function validateDigitsCount (word){
        let digitsCounter = 0;

        for(let i = 0; i < word.length; i++){
            let symbol = word[i];
            if(!isNaN(symbol)){
                digitsCounter++;
            }
        }

        return digitsCounter >= 2;
    }

    let isValidLength = validateLength(password);
    let areValidSymbols = ValidateSymbols(password);
    let areDigitsEnough = validateDigitsCount(password);

    if (!isValidLength) {
        console.log("Password must be between 6 and 10 characters");
    }
    if(!areValidSymbols){
        console.log("Password must consist only of letters and digits");
    }
    if(!areDigitsEnough){
        console.log("Password must have at least 2 digits");
    }

    if(isValidLength && areValidSymbols && areDigitsEnough){
        console.log("Password is valid");
    }
}

passwordValidation('Pa$s$s');