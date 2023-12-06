function lockedProfile() {
    let allButtons = Array.from(document.querySelectorAll("button"));
    console.log(allButtons);

    for (const btn of allButtons) {
        btn.addEventListener("click", showMore);
    }

    function showMore(e) {
        let btn = e.target;
        let parent = btn.parentElement;
        let children = Array.from(parent.children);

        let unlocked = children[4];
        let hiddenField = children[9];

        if(!unlocked.checked){
            return;
        }

        if(btn.textContent === "Show more"){
            hiddenField.style.display = "block";
            btn.textContent = "Hide it";
        } else if(btn.textContent === "Hide it"){
            hiddenField.style.display = "none";
        }
    }
}