function attachEvents() {
    document.getElementById("btnLoad").addEventListener("click", getPhones);
    document.getElementById("btnCreate").addEventListener("click", createContact);

    async function getPhones() {
        const response = await fetch ("http://localhost:3030/jsonstore/phonebook");
        const phonesInfo = await response.json();

        const phoneBook = document.getElementById("phonebook");

        Object.values(phonesInfo).forEach(contact => {
            const li = document.createElement("li");
            const deleteBtn = document.createElement("button");
            deleteBtn.textContent = "Delete";

            li.textContent = `${contact.person}: ${contact.phone}`;
            li.appendChild (deleteBtn);

            phoneBook.appendChild (li);

            deleteBtn.addEventListener("click", deleteContact);

            function deleteContact() {
                const id = contact._id;

                fetch (`http://localhost:3030/jsonstore/phonebook${id}`, {
                    method: "DELETE",
                });

                li.remove();
            }
        })
    }

    function createContact() {
        const person = document.getElementById("person").value;
        const phone = document. getElementById("phone").value;

        fetch ("http://localhost:3030/jsonstore/phonebook", {
            method: "POST",
            body: JSON.stringify (
                {
                    person,
                    phone
                }
            )
        })
        .then(res => res.json())
        .then(() => {
            getPhones();
            document.getElementById("person").value = "";
            document. getElementById("phone").value = "";
        })
    }
}

attachEvents();