async function solution() {
    let section = document.getElementById("main");
    let articlesResponse = await fetch("http://localhost:3030/jsonstore/advanced/articles/list")
    let articles = await articlesResponse.json();

    Object.values(articles).forEach(a => {
        let articleTitle = a.title;
        let articleId = a._id;

        fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${articleId}`)
            .then(res => res.json())
            .then((result) => {
                let articleContent = result["content"];

                let articleDiv = document.createElement("div");
                articleDiv.innerHTML = `
                <div class="accordion">
                    <div class="head">
                        <span>${articleTitle}</span>
                        <button class="button" id="${articleId}">More</button>
                    </div>
                    <div class="extra">
                        <p>${articleContent}</p>
                    </div>
                </div>
                `;

                section.appendChild(articleDiv);

                let moreBtn = articleDiv.querySelector("button");
                moreBtn.addEventListener("click", showHidden);

                function showHidden() {
                    let hiddenDiv = articleDiv.querySelector(".extra");
                    console.log(moreBtn);
                    console.log(result);
                    if (moreBtn.textContent === "More") {
                        hiddenDiv.style.display = "block";
                        moreBtn.textContent = "Less";
                    } else if (moreBtn.textContent === "Less") {
                        hiddenDiv.style.display = "none";
                        moreBtn.textContent = "More";
                    }
                }

            });

    });
}