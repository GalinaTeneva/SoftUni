function solve (fruitType, fruitWeight, fruitPrice) {
    
    let totalPrice = fruitWeight * fruitPrice;
    console.log(`I need $${(totalPrice / 1000).toFixed(2)} to buy ${(fruitWeight / 1000).toFixed(2)} kilograms ${fruitType}.`);
}

solve('apple', 1563, 2.35);