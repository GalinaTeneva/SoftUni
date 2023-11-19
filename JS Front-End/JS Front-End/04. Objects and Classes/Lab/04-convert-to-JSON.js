function convertToJson(firstName, lastName, hairColor ){
    let person = {firstName, lastName, hairColor}

    console.log(JSON.stringify(person));
}

convertToJson('Peter', 'Smith', 'Blond');