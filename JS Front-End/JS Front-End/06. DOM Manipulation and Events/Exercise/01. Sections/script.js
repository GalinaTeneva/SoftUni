function create(words) {
   const elementsContainer = document.getElementById("content");

   for(let i = 0; i < words.length; i++){
      let newParagraph = document.createElement("p");
      newParagraph.textContent = words[i];
      newParagraph.style.display = "none";

      let newDiv = document.createElement("div");
      newDiv.appendChild(newParagraph);
      
      newDiv.addEventListener("click", displayText);

      elementsContainer.appendChild(newDiv);
   }
   
   function displayText(e) {
      let targetDiv = e.currentTarget;
      targetDiv.getElementsByTagName("p")[0].style.display = "inline";
   }
}