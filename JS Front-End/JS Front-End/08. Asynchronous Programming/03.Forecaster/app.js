function attachEvents() {
    let degreesSymbol = "&#176;";
    let locationCode = "";
    let inputField = document.getElementById("location");
    let getWeatherBtn = document.getElementById("submit");
    let forecastDiv = document.getElementById("forecast");
    let currentForecastDiv = document.getElementById("current");
    let upcomingForecastDiv = document.getElementById("upcoming");
    getWeatherBtn.addEventListener("click", getWeather);

    let forecastsDiv = document.createElement("div");
    forecastsDiv.classList.add("forecasts");
    currentForecastDiv.appendChild(forecastsDiv);

    let forecastInfoDiv = document.createElement("div");
    forecastInfoDiv.classList.add("forecast-info");
    upcomingForecastDiv.appendChild(forecastInfoDiv);

    function getWeather(e) {
        fetch("http://localhost:3030/jsonstore/forecaster/locations")
            .then(res => res.json())
            .then(result => {
                forecastsDiv.textContent = "";
                forecastInfoDiv.textContent = "";

                for (const location of result) {

                    if (location["name"] === inputField.value) {
                        locationCode = location["code"];
                        break;
                    }
                }

                return fetch("http://localhost:3030/jsonstore/forecaster/today/" + locationCode);
            })
            .then(response => response.json())
            .then(result => {
                let currLocationName = result["name"];
                let currLocationHighTemp = result["forecast"]["high"];
                let currLocationLowTemp = result["forecast"]["low"];

                let currCondition = result["forecast"]["condition"];
                let currConditionSymbol = getConditionSymbol(currCondition);

                let conditionSymbolSpan = document.createElement("span");
                conditionSymbolSpan.classList.add("condition", "symbol");
                conditionSymbolSpan.innerHTML = currConditionSymbol;
                forecastsDiv.appendChild(conditionSymbolSpan);

                let conditionSpan = document.createElement("span");
                conditionSpan.classList.add("condition");
                forecastsDiv.appendChild(conditionSpan);

                let locationNameSpan = document.createElement("span");
                locationNameSpan.classList.add("forecast-data");
                locationNameSpan.textContent = currLocationName;
                conditionSpan.appendChild(locationNameSpan);

                let locationHighAndLowTempSpan = document.createElement("span");
                locationHighAndLowTempSpan.classList.add("forecast-data");
                locationHighAndLowTempSpan.innerHTML = `${currLocationLowTemp}${degreesSymbol}/${currLocationHighTemp}${degreesSymbol}`;
                conditionSpan.appendChild(locationHighAndLowTempSpan);

                let weatherSpan = document.createElement("span");
                weatherSpan.classList.add("forecast-data");
                weatherSpan.textContent = currCondition;
                conditionSpan.appendChild(weatherSpan);

                forecastDiv.style.display = "block";

                return fetch("http://localhost:3030/jsonstore/forecaster/upcoming/" + locationCode)
            })
            .then(response => response.json())
            .then(result => {
                let upcomingSpan = document.createElement("span");
                upcomingSpan.classList.add("upcoming");
                forecastInfoDiv.appendChild(upcomingSpan);

                let futureForecast = result["forecast"];
                for (const item of futureForecast) {
                    let futureCondition = item["condition"];
                    let futureHighTemp = item["high"];
                    let futureLowTemp = item["low"];

                    let futureConditionSymbol = getConditionSymbol(futureCondition);
                    let symbolSpan = document.createElement("span");
                    symbolSpan.innerHTML = futureConditionSymbol;
                    symbolSpan.classList.add("symbol");
                    upcomingSpan.appendChild(symbolSpan);

                    let futureHighAndLowTempSpan = document.createElement("span");
                    futureHighAndLowTempSpan.classList.add("forecast-data");
                    futureHighAndLowTempSpan.innerHTML = `${futureLowTemp}${degreesSymbol}/${futureHighTemp}${degreesSymbol}`;
                    upcomingSpan.appendChild(futureHighAndLowTempSpan);

                    let futureWeatherSpan = document.createElement("span");
                    futureWeatherSpan.classList.add("forecast-data");
                    futureWeatherSpan.textContent = futureCondition;
                    upcomingSpan.appendChild(futureWeatherSpan);
                }
            });
    }

    function getConditionSymbol(text) {
        result = "";
        switch (text) {
            case "Sunny":
                result = "&#x2600;";
                break;
            case "Partly sunny":
                result = "&#x26C5;";
                break;
            case "Overcast":
                result = "&#x2601;";
                break;
            case "Rain":
                result = "&#x2614;";
                break;
            case "Rain":
                result = "&#x2614;";
                break;
        }

        return result;
    }
}

attachEvents();