function solve() {
  let inputText = document.getElementById("input").value;
  let outputField = document.getElementById("output");

  let sentencesArr = inputText.split(".");

  sentencesArr = sentencesArr.filter(s => s.length > 0).map(s => s += ".");

  while (sentencesArr.length > 0){
    let paragraph = document.createElement("p");
    paragraph.textContent = sentencesArr.splice(0, 3).join(" ");
    outputField.appendChild(paragraph);
  }
}