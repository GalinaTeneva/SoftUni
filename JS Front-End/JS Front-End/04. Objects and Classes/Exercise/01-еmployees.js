function createEmployeeList(input){
    class Employee{
        constructor (fullName, personalNumber){
            this.fullName = fullName;
            this.personalNumber = personalNumber;
        }
    }

    let employeeList = [];

    for (const name of input) {
        let personalNumber = name.length;
        let employee = new Employee(name, personalNumber);
        employeeList.push(employee);
    }

    printEmployeeList(employeeList);

    function printEmployeeList(employeeList){
        for (const employee of employeeList) {
            console.log(`Name: ${employee.fullName} -- Personal Number: ${employee.personalNumber}`);
        }
    }
}

createEmployeeList([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );