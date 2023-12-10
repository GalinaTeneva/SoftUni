function getInfo() {
    let inputField = document.getElementById("stopId");
    let busStopNameField = document.getElementById("stopName");
    let bussesUl = document.getElementById("buses");
    let inputFieldText = inputField.value;
    let requestLink = `http://localhost:3030/jsonstore/bus/businfo/${inputFieldText}`;

    bussesUl.textContent = "";

    fetch(requestLink)
    .then(res => res.json())
    .then(result => {
        let bustStopName = result["name"];
        busStopNameField.textContent = bustStopName;

        let busses = result["buses"];
        for (const buss in busses) {
            let newLi = document.createElement("li");
            newLi.textContent = `Bus ${buss} arrives in ${busses[buss]} minutes`;
            bussesUl.appendChild(newLi);
        }
    })
    .catch((err) => {
        busStopNameField.textContent = "Error";
    });
    
}