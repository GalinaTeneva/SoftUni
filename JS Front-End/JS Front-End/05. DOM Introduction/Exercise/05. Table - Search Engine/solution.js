function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchInput = document.getElementById("searchField");
      let allElements = document.querySelectorAll("tbody tr");

      for(let element of allElements){
         element.classList.remove("select");
         if(element.innerHTML.includes(searchInput.value) && searchInput.value !== ""){
            element.className = "select";
         }
      }

      searchInput.value = "";
   }
}