function makeDictionary(input) {
    let dictionary = {};

    for (const element of input) {
        let currObject = JSON.parse(element);
        let entries = Object.entries(currObject);

        for (let [key, value] of entries) {
            dictionary[key] = value;
        }
    }

    let sortedDictionary = sorDictionary(dictionary);

    for (const iterator of sortedDictionary) {
        console.log(`Term: ${iterator[0]} => Definition: ${iterator[1]}`)
    }

    function sorDictionary(dictionary){
        let entries = Object.entries(dictionary);

        return entries.sort((a, b) => a[0].localeCompare(b[0]));
    }
}

makeDictionary([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
]);