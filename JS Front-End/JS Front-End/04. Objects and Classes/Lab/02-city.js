function cityObject(city){
    let entries = Object.entries(city);

    for (const [key, value] of entries) {
        console.log(`${key} -> ${value}`);
    }
}

cityObject({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
});