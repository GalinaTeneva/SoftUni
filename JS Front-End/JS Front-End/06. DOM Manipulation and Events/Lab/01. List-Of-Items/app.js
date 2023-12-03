function addItem() {
    let newItemText = document.getElementById("newItemText").value;
    
    let parentElement = document.getElementById("items");
    let elementToAdd = document.createElement("li");
    elementToAdd.textContent = newItemText;

    parentElement.appendChild(elementToAdd);
}