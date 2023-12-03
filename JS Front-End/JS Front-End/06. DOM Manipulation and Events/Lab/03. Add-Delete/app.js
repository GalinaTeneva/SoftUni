function addItem() {
    let newItemText = document.getElementById("newItemText").value;
    let list = document.getElementById("items");

    let deleteLink = document.createElement("a");
    deleteLink.href = "#";
    deleteLink.textContent = "[Delete]";

    deleteLink.addEventListener("click", deleteItem);

    let newListElement = document.createElement("li");
    newListElement.textContent = newItemText;
    newListElement.appendChild(deleteLink);
    list.appendChild(newListElement);

    function deleteItem(e){
        let row = e.currentTarget.parentNode;
        row.remove();
    }
}