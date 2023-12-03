function search() {
   let towns = Array.from(document.getElementsByTagName("li"));
   let searchBoxText = document.getElementById("searchText").value;
   let result = document.getElementById("result");
   let matches = 0;

   for (let town of towns) {
      town.style.fontWeight = "";
      town.style.textDecoration = "";
   }


   for (let town of towns) {
      if (town.textContent.includes(searchBoxText)) {
         matches++;
         town.style.fontWeight = "bold";
         town.style.textDecoration = "underline";
      }
   }

   result.textContent = `${matches} matches found`;
}
