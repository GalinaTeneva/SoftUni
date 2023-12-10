function solve() {
    let departBtn = document.getElementById("depart");
    let arriveBtn = document.getElementById("arrive");
    let infoBox = document.getElementsByClassName("info")[0];
    let bussStopID = "depot";
    let busStopName = "";

    function depart() {
        departBtn.disabled = true;
        arriveBtn.disabled = false;

        fetch("http://localhost:3030/jsonstore/bus/schedule/" + bussStopID)
            .then(ress => ress.json())
            .then(result => {
                busStopName = result["name"];
                infoBox.textContent = `Next stop ${busStopName}`;
                bussStopID = result["next"];
            })
    }

    async function arrive() {
        // TODO:
        departBtn.disabled = false;
        arriveBtn.disabled = true;

        infoBox.textContent = `Arriving at ${busStopName}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();