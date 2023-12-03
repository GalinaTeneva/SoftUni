function solve() {
  let namingConvention = document.getElementById("naming-convention").value;
  let inputText = document.getElementById("text").value.toLowerCase();
  
  let textArr = inputText.split(" ");
  let resultArr = [];

  if(namingConvention === "Camel Case"){
    resultArr.push(textArr[0]);

    for(let i = 1; i < textArr.length; i++){
      let currWord = textArr[i].charAt(0).toUpperCase() + textArr[i].slice(1);
      resultArr.push(currWord);
    }
  } else if (namingConvention === "Pascal Case"){
    for(let i = 0; i < textArr.length; i++){
      let currWord = textArr[i].charAt(0).toUpperCase() + textArr[i].slice(1);
      resultArr.push(currWord);
    }
  } else {
    document.getElementById("result").textContent = "Error!";
    return
  }

  document.getElementById("result").textContent = resultArr.join("");
}