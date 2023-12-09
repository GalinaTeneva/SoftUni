function attachEvents() {
  let loadBtn = document.getElementById("loadBooks");
  let createBtn = document.querySelector("#form button");

  const titleInput = document.querySelector("#form input[name=title]");
  const authorInput = document.querySelector("#form input[name=author]");

  loadBtn.addEventListener("click", getBooks);
  createBtn.addEventListener("click", createBook);

  function getBooks(e) {
    let tableRows = document.querySelectorAll("tbody tr");

    fetch("http://localhost:3030/jsonstore/collections/books")
      .then(res => res.json())
      .then(result => {
        let books = Object.values(result);

        for (let i = 0; i < books.length; i++) {
          let currAuthor = books[i]["author"];
          let currBookName = books[i]["title"];
          let currCells = tableRows[i].children;

          currCells[0].textContent = currBookName;
          currCells[1].textContent = currAuthor;
        }
      });
  }

  function createBook(e) {
    e.preventDefault();

    let table = document.querySelectorAll("tbody")[0];
    const title = titleInput.value;
    const author = authorInput.value;

    fetch("http://localhost:3030/jsonstore/collections", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        title,
        author,
      })
    })
      .then(res => res.json())
      .then(result => {
        let titleCell = document.createElement("td");
        titleCell.textContent = title;

        let authorCell = document.createElement("td");
        authorCell.textContent = author;

        let editBtn = document.createElement("button");
        editBtn.textContent = "Edit";
        let deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete";

        let buttonsCell = document.createElement("td");
        buttonsCell.appendChild(editBtn);
        buttonsCell.appendChild(deleteBtn);

        let bookRow = document.createElement("tr");
        bookRow.appendChild(titleCell);
        bookRow.appendChild(authorCell);
        bookRow.appendChild(buttonsCell);

        table.appendChild(bookRow);
      })
      .catch(err => {
        console.log(err);
      })


  }
}

attachEvents();