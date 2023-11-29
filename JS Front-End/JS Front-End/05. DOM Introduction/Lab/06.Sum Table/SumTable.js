function sumTable() {
    let rows = document.querySelectorAll("table tr");

    let totalSum = 0;

    for(let i = 1; i < rows.length; i++){
        let cells = rows[i].children;
        let cellPrice = Number(cells[1].textContent);
        totalSum += cellPrice;
    }

    document.getElementById("sum").textContent = totalSum;
}