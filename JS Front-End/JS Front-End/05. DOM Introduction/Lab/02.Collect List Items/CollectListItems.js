function extractText() {
    let elementsArr = Array.from(document.getElementsByTagName("li"));
    let textArea = document.getElementById("result");
    for (const element of elementsArr) {
        textArea.value += element.textContent + "\n";
    }
}