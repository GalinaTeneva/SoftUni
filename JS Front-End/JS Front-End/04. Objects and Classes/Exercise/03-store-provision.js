function storeProvisionSolve(currStockArr, orderArr) {
    let storeStock = {};

    for (let i = 0; i < currStockArr.length; i += 2) {
        let currProduct = currStockArr[i];
        let currQuantity = currStockArr[i + 1];

        storeStock[currProduct] = Number(currQuantity);
    }

    for (let i = 0; i < orderArr.length; i += 2) {
        let currProduct = orderArr[i];
        let currQuantity = Number(orderArr[i + 1]);

        if (storeStock.hasOwnProperty(currProduct)){
            storeStock[currProduct] += currQuantity;
        } else {
            storeStock[currProduct] = currQuantity;
        }
    }

    for (const pair in storeStock) {
        console.log(`${pair} -> ${storeStock[pair]}`)
    }
}

storeProvisionSolve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
    );