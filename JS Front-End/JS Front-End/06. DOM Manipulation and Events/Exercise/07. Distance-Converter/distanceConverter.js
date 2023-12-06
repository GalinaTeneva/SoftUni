function attachEventsListeners() {
    let [inputField, button, outputField] = document.getElementsByTagName("input");
    let [inputOption, outputOption] = document.getElementsByTagName("select");

    let convertionRates = {
        "km": 1000,
        "m": 1,
        "cm": 0.01,
        "mm": 0.001,
        "mi": 1609.34,
        "yrd": 0.9144,
        "ft": 0.3048,
        "in": 0.0254
    }

    button.addEventListener("click", convert);

    function convert(e) {
        let inputDistance = inputField.value;
        let inputUnits = inputOption.value;
        let outputUnits = outputOption.value;

        let result = inputDistance * convertionRates[inputUnits] / convertionRates[outputUnits];

        outputField.value = result;
    }
}