function solve() {
  const allTextFields = document.querySelectorAll("textarea");
  let inputTextField = allTextFields[0];
  let outputTextField = allTextFields[1];

  const allButtons = document.querySelectorAll("button");
  let generateBtn = allButtons[0];
  let buyBtn = allButtons[1];

  generateBtn.addEventListener("click", generateItem);
  buyBtn.addEventListener("click", getOrderSummary);

  function generateItem(e) {
    let inputString = JSON.parse(inputTextField.value);
    for (product of inputString) {
      let newRow = document.createElement("tr");

      let tableBody = document.getElementsByTagName("tbody")[0];

      let imgElement = document.createElement("img");
      let imgLink = product["img"];
      
      imgElement.setAttribute("src", imgLink);
      let imgCell = document.createElement("td");
      imgCell.appendChild(imgElement);
      newRow.appendChild(imgCell);

      let nameParagraph = document.createElement("p");
      nameParagraph.textContent = product["name"];
      let nameCell = document.createElement("td");
      nameCell.appendChild(nameParagraph);
      newRow.appendChild(nameCell);

      let priceParagraph = document.createElement("p");
      priceParagraph.textContent = product["price"];
      let priceCell = document.createElement("td");
      priceCell.appendChild(priceParagraph);
      newRow.appendChild(priceCell);

      let decFactorParagraph = document.createElement("p");
      decFactorParagraph.textContent = product["decFactor"];
      let decFactorCell = document.createElement("td");
      decFactorCell.appendChild(decFactorParagraph);
      newRow.appendChild(decFactorCell);

      let checkBox = document.createElement("input");
      checkBox.setAttribute("type", "checkbox");
      let checkBoxCell = document.createElement("td");
      checkBoxCell.appendChild(checkBox);
      newRow.appendChild(checkBoxCell);

      tableBody.appendChild(newRow);
    }
    console.log(inputString);
  }

  function getOrderSummary(e) {
    let allRows = Array.from(document.querySelectorAll("tbody tr"));

    let boughtProductsArr = [];
    let totalCost = 0;
    let decFactorSum = 0;

    for (let row of allRows) {
      let productCheckBox = row.querySelector("input");

      if (productCheckBox.checked) {
        let productInfo = row.querySelectorAll("p");
        let productName = productInfo[0].textContent;
        let productPrice = Number(productInfo[1].textContent);
        let productDecFactor = Number(productInfo[2].textContent);

        boughtProductsArr.push(productName);
        totalCost += productPrice;
        decFactorSum += productDecFactor;
      }
    }

    if (boughtProductsArr.length > 0) {
      let resultString = (`Bought furniture: ${boughtProductsArr.join(", ")}\n`) +
        (`Total price: ${totalCost.toFixed(2)}\n`) +
        (`Average decoration factor: ${decFactorSum / boughtProductsArr.length}`);

      outputTextField.textContent = resultString;
      console.log(resultString);
    }
  }
}