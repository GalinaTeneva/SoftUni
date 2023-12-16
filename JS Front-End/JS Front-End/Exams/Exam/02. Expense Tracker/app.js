window.addEventListener("load", solve);

function solve() {

    let expenseField = document.getElementById("expense");
    let amountField = document.getElementById("amount");
    let dateField = document.getElementById("date");

    let expensePreviewUl = document.getElementById("preview-list");
    let expenseUl = document.getElementById("expenses-list");

    let deleteBtn = document.querySelector("#expenses button");
    deleteBtn.addEventListener("click", () => {
        location.reload();
    })

    let addBtn = document.getElementById("add-btn");
    addBtn.addEventListener("click", addExpense);

    function addExpense() {
        expenseType = expenseField.value;
        amount = amountField.value;
        date = dateField.value;

        let isInfoValid = expenseType !== "" && amount !== "" && date !== "";

        if (isInfoValid) {

            let liElement = document.createElement("li");
            liElement.classList.add("expense-item");

            let articleElement = document.createElement("article");

            let expenseTypeElement = document.createElement("p");
            expenseTypeElement.textContent = `Type: ${expenseType}`;
            articleElement.appendChild(expenseTypeElement);

            let amountElement = document.createElement("p");
            amountElement.textContent = `Amount: ${amount}$`;
            articleElement.appendChild(amountElement);

            let dateElement = document.createElement("p");
            dateElement.textContent = `Date: ${date}`;
            articleElement.appendChild(dateElement);

            liElement.appendChild(articleElement);

            editBtn = document.createElement("button");
            editBtn.classList.add("btn", "edit");
            editBtn.textContent = "edit";

            okBtn = document.createElement("button");
            okBtn.classList.add("btn", "ok");
            okBtn.textContent = "ok";

            let buttonsDiv = document.createElement("div");
            buttonsDiv.classList.add("buttons")
            buttonsDiv.appendChild(editBtn);
            buttonsDiv.appendChild(okBtn);

            liElement.appendChild(buttonsDiv);

            expensePreviewUl.appendChild(liElement);
            addBtn.disabled = true;
        }

        clearInputFields()

        editBtn.addEventListener("click", editExpense);
        okBtn.addEventListener("click", addToExpenseList);

    }

    function clearInputFields() {
        expenseField.value = "";
        amountField.value = "";
        dateField.value = "";
    }

    function editExpense(e) {
        let targetElement = e.currentTarget;
        let liElement = targetElement.parentNode.parentNode;
        let expenseInfo = liElement.querySelector("article").children;

        let expenseTypeTokens = expenseInfo[0].textContent.split(": ");
        let amountTokens = expenseInfo[1].textContent.split(": ");
        let dateTokens = expenseInfo[2].textContent.split(": ");

        expenseField.value = expenseTypeTokens[1];
        //let testlength = amountTokens[1].length;
        let expenseFieldText = amountTokens[1].substring(0, amountTokens[1].length - 1);
        amountField.value = Number(expenseFieldText);
        dateField.value = dateTokens[1];

        expensePreviewUl.removeChild(liElement);
        addBtn.disabled = false;
    }

    function addToExpenseList(e) {
        let targetElement = e.currentTarget;
        let liElement = targetElement.parentNode.parentNode;
        let buttonsDiv = targetElement.parentNode;

        liElement.removeChild(buttonsDiv);
        
        expenseUl.appendChild(liElement);

        addBtn.disabled = false;
    }
}