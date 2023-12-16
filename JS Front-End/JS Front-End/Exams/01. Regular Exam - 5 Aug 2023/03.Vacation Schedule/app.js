solve();

function solve() {
    const baseURL = "http://localhost:3030/jsonstore/tasks/";

    let loadBtn = document.getElementById("load-vacations");
    let addBtn = document.getElementById("add-vacation");
    let editBtn = document.getElementById("edit-vacation");

    let allCourcesListDiv = document.getElementById("list");
    let formElement = document.querySelector("#form form");

    let nameInputField = document.getElementById("name");
    let daysInputField = document.getElementById("num-days");
    let startDateInputField = document.getElementById("from-date");

    loadBtn.addEventListener("click", getAllCourses);
    addBtn.addEventListener("click", addVacation);
    editBtn.addEventListener("click", editVacation);

    async function getAllCourses() {
        allCourcesListDiv.innerHTML = "";

        let response = await fetch(baseURL);
        let courses = await response.json();

        Object.values(courses).forEach(c => {
            let name = c.name;
            let days = c.days;
            let date = c.date;
            let id = c._id;

            let newDivContainer = document.createElement("div");
            newDivContainer.classList.add("container");
            newDivContainer.innerHTML = `
                        <h2>${name}</h2>
                        <h3>${date}</h3>
                        <h3>${days}</h3>
                        <button class="change-btn">Change</button>
                        <button class="done-btn">Done</button>`;

            allCourcesListDiv.appendChild(newDivContainer);

            let changeBtn = newDivContainer.querySelector(".change-btn");
            changeBtn.addEventListener("click", () => {
                nameInputField.value = name;
                daysInputField.value = days;
                startDateInputField.value = date;

                newDivContainer.remove();

                addBtn.disabled = true;
                editBtn.disabled = false;

                formElement.dataset.vacation = id;
            });

            let doneBtn = newDivContainer.querySelector(".done-btn");
            doneBtn.addEventListener("click", () => {

                fetch(`${baseURL}${id}`, {
                    method: "DELETE"
                })
                .then(getAllCourses());
            })
        })

    }

    async function addVacation(e) {
        e.preventDefault();
        isValidInput = nameInputField.value !== "" && daysInputField.value !== "" && startDateInputField.value !== "";
        if (isValidInput) {
            let vacation = {
                name: nameInputField.value,
                days: daysInputField.value,
                date: startDateInputField.value
            };

            await fetch(baseURL, {
                method: "POST",
                body: JSON.stringify(vacation)
            });
        }

        nameInputField.value = "";
        daysInputField.value = "";
        startDateInputField.value = "";

        await getAllCourses();
    }

    async function editVacation(e) {
        e.preventDefault();

        let vacationId = formElement.dataset.vacation;

        let vacation = {
            _id: vacationId,
            name: nameInputField.value,
            days: daysInputField.value,
            date: startDateInputField.value
        };

        await fetch(`${baseURL}${vacationId}`, {
            method: "PUT",
            body: JSON.stringify(vacation)
        })

        await getAllCourses();

        addBtn.disabled = false;
        editBtn.disabled = true;
        
        nameInputField.value = "";
        daysInputField.value = "";
        startDateInputField.value = "";

        delete formElement.dataset.vacation;
    }
}


