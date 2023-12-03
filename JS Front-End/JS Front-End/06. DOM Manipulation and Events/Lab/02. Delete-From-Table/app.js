function deleteByEmail() {
    let emailToDeleteText = document.querySelector("label input").value;
    let allTableRows = Array.from(document.querySelector("tbody").children);

    let resultElement = document.getElementById("result");
    let isRemoved = false;
    for (const row of allTableRows) {
        let emailCell = row.children[1];

        if(emailCell.textContent === emailToDeleteText){
            row.remove();
            isRemoved = true;
        }
    }

    if(isRemoved){
        resultElement.textContent = "Deleted";
    } else {
        resultElement.textContent = "Not found.";
    }
}