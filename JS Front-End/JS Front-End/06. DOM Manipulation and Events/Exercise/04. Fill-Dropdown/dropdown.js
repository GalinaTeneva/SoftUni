function addItem() {
    let menuElement = document.getElementById("menu");

    let newItemText = document.getElementById("newItemText");
    let newItemValue = document.getElementById("newItemValue");

    let newItemOption = document.createElement("option");
    newItemOption.textContent = newItemText.value;
    newItemOption.value = newItemValue.value;

    if(newItemText.value !== "" && newItemValue.value !== ""){
        menuElement.appendChild(newItemOption);
    }

    newItemText.value = "";
    newItemValue.value = "";
}