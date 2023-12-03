function solve() {
   const addButtons = Array.from(document.querySelectorAll("button.add-product"));

   const textField = document.querySelector("textarea");
   const checkOutBtn = document.querySelector("button.checkout");
   
   let boughtProducts = [];
   let totalPrice = 0;
   addButtons.forEach(b => {
      b.addEventListener("click", addToCart);
   })

   function addToCart(e){
      const currProduct = e.currentTarget.parentNode.parentNode;
      const productTitle = currProduct.querySelector(".product-title").textContent;
      const productPrice = currProduct.querySelector(".product-line-price").textContent;
      
      if(!boughtProducts.includes(productTitle)){
         boughtProducts.push(productTitle);
      }
      totalPrice += Number(productPrice);

      textField.value += `Added ${productTitle} for ${productPrice} to the cart.\n`;
   }

   checkOutBtn.addEventListener("click", checkOut);

   function checkOut(e) {
      textField.value += `You bought ${boughtProducts.join(", ")} for ${totalPrice.toFixed(2)}.`;

      addButtons.forEach(b => {
         b.removeEventListener("click", addToCart);
      });
      checkOutBtn.removeEventListener("click", checkOut);
   }
}