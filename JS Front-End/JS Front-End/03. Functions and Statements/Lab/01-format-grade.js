function formatGrade(grade) {
    let textResult = "";

    if (grade < 3.00) {
        textResult = "Fail";
    } else if (grade >= 3.00 && grade < 3.50) {
        textResult = "Poor";
    }
    else if (grade >= 3.50 && grade < 4.50) {
        textResult = "Good"; 
    }
    else if (grade >= 4.50 && grade < 5.50) {
        textResult = "Very good";
    }
    else if (grade >= 5.50){
        textResult = "Excellent";
    }

    if (grade >= 3.00){
        console.log(`${textResult} (${grade.toFixed(2)})`)
    }
    else {
        console.log(`${textResult} (2)`)
    }
}

formatGrade(2.50);