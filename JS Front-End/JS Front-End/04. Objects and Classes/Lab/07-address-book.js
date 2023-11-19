function adressBook(input){
    let addressBook = {};

    for (const item of input) {
        let [name, address] = item.split(":");
        addressBook[name] = address;
    }

    let sortedAddressBook = sortAddressBook(addressBook);
    
    for(item of sortedAddressBook){
        console.log(`${item[0]} -> ${item[1]}`);
    }

    function sortAddressBook(addressBook){
        let entries = Object.entries(addressBook);

        return entries.sort((a, b) => a[0].localeCompare(b[0]));
    }
}

adressBook(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
);