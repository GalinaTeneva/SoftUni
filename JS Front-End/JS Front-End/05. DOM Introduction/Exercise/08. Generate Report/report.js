function generateReport() {
    let personObj = {};
    let allPersons = [];
    let columnSetNumbers = [];

    let allColumns = document.querySelectorAll("thead tr th input");

    for (let i = 0; i < allColumns.length; i++){
        let isChecked = allColumns[i].checked;

        if(isChecked){
            columnSetNumbers.push(i);
        }
    }

    let columnTitles = document.querySelectorAll("thead tr")[0].getElementsByTagName("th");
    let rowsCount = document.querySelectorAll("tbody tr").length;

    for (let row = 0; row < rowsCount; row++){
        columnSetNumbers.forEach(element => {
            let key = columnTitles[element].textContent.trim().toLowerCase();
            let value = document.querySelectorAll("tbody tr")[row].getElementsByTagName("td")[element].textContent;
            personObj[key] = value;
        });

        allPersons.push(Object.assign(personObj));
        personObj = {};
    }

    document.getElementById("output").innerHTML = JSON.stringify(allPersons);
}