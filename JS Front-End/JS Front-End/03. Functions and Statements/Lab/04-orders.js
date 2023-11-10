function calcPrice(product, quantity) {
    const coffeePrice = 1.50;
    const waterPrice = 1.00;
    const cokePrice = 1.40;
    const snacksPrice = 2.00;

    let productPrice = 0;

    switch (product) {
        case 'coffee':
            productPrice = coffeePrice;
            break;
        case 'water':
            productPrice = waterPrice;
            break;
        case 'coke':
            productPrice = cokePrice;
            break
        case 'snacks':
            productPrice = snacksPrice;
            break;
    }
    console.log(`${(productPrice*quantity).toFixed(2)}`);
}

calcPrice("coffee", 2);