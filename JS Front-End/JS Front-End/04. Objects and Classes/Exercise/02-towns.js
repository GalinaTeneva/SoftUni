function createTown(input){
    class Town {
        constructor(townName, townLatitude, townLongitude){
            this.town = townName;
            this.latitude = townLatitude;
            this.longitude = townLongitude;
        }
    }

    let townsArr = [];
    
    for (const element of input) {
        let currTownInfo = element.split(" | ");
        let name = currTownInfo[0];
        let latitude = Number(currTownInfo[1]);
        let longitude = Number(currTownInfo[2]);
        let  currTown = new Town(name, latitude, longitude);
        townsArr.push(currTown)
    }

    for (const town of townsArr) {
        console.log(`{ town: '${town.town}', latitude: '${town.latitude.toFixed(2)}', longitude: '${town.longitude.toFixed(2)}' }`);
    }
}

createTown(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);