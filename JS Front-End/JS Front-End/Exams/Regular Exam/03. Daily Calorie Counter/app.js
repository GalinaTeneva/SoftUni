solve();

function solve() {
    const baseURL = "http://localhost:3030/jsonstore/tasks/";

    let loadBtn = document.getElementById("load-meals");
    let addBtn = document.getElementById("add-meal");
    let editBtn = document.getElementById("edit-meal");

    let allMealsListDiv = document.getElementById("list");
    let formElement = document.querySelector("#form form");

    let foodInputField = document.getElementById("food");
    let timeInputField = document.getElementById("time");
    let caloriesInputField = document.getElementById("calories");


    loadBtn.addEventListener("click", loadMeals);
    addBtn.addEventListener("click", addMeal);
    editBtn.addEventListener("click", editMeal);

    async function loadMeals() {
        allMealsListDiv.innerHTML = "";

        let response = await fetch(baseURL);
        let meals = await response.json();

        Object.values(meals).forEach(m => {
            let calories = m.calories;
            let food = m.food;
            let time = m.time;
            let id = m._id;

            let newDivContainer = document.createElement("div");
            newDivContainer.classList.add("meal");
            newDivContainer.innerHTML = `
                <h2>${food}</h2>
                <h3>${time}</h3>
                <h3>${calories}</h3>
                <div id="meal-buttons">
                    <button class="change-meal">Change</button>
                    <button class="delete-meal">Delete</button>
                </div>`;

            allMealsListDiv.appendChild(newDivContainer);

            let changeBtn = newDivContainer.querySelector(".change-meal");
            changeBtn.addEventListener("click", () => {
                foodInputField.value = food;
                timeInputField.value = time;
                caloriesInputField.value = calories;

                newDivContainer.remove();

                addBtn.disabled = true;
                editBtn.disabled = false;

                formElement.dataset.meal = id;
            });

            let deleteBtn = newDivContainer.querySelector(".delete-meal");
            deleteBtn.addEventListener("click", () => {

                fetch(`${baseURL}${id}`, {
                    method: "DELETE"
                })
                .then(loadMeals());
            })
        })
    }

    async function addMeal(e) {
        e.preventDefault();
        isValidInput = foodInputField.value !== "" && timeInputField.value !== "" && caloriesInputField.value !== "";

        if (isValidInput) {
            let meal = {
                food: foodInputField.value,
                time: timeInputField.value,
                calories: caloriesInputField.value
            };

            await fetch(baseURL, {
                method: "POST",
                body: JSON.stringify(meal)
            });

            clearInputFields();

            await loadMeals();
        }
    }

    async function editMeal(e) {
        e.preventDefault();

        let mealId = formElement.dataset.meal;

        let meal = {
            food: foodInputField.value,
            time: timeInputField.value,
            calories: caloriesInputField.value,
            _id: mealId
        }

        await fetch(`${baseURL}${mealId}`, {
            method: "PUT",
            body: JSON.stringify(meal)
        });

        await loadMeals();

        editBtn.disabled = true;
        addBtn.disabled = false;

        clearInputFields();

        delete formElement.dataset.meal;
    }


    function clearInputFields() {
        foodInputField.value = "";
        timeInputField.value = "";
        caloriesInputField.value = "";
    }
}