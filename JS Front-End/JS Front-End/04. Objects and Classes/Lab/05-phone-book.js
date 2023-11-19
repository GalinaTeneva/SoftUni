function generatePhoneBook(input) {
    let phoneBookArr = {};

    for (const pairArr of input) {
        let [name, phone] = pairArr.split(" ");

        phoneBookArr[name] = phone;
    }

    for (const key in phoneBookArr) {
        console.log(`${key} -> ${phoneBookArr[key]}`);
    }
}

generatePhoneBook(['George 0552554',
'Peter 087587',
'George 0453112',
'Bill 0845344']
);