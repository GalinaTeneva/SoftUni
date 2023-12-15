async function lockedProfile() {
    let mainField = document.getElementById("main");
    let div = document.querySelector(".profile");
    mainField.removeChild(div);

    let response = await fetch("http://localhost:3030/jsonstore/advanced/profiles");
    let users = await response.json();
    let userCounter = 1;
    Object.values(users).forEach(user => {
        let profileDiv = document.createElement("div");
        profileDiv.innerHTML = `
        <img src="./iconProfile2.png" class="userIcon" />
				<label>Lock</label>
				<input type="radio" name="user${userCounter}Locked" value="lock" checked>
				<label>Unlock</label>
				<input type="radio" name="user${userCounter}Locked" value="unlock"><br>
				<hr>
				<label>Username</label>
				<input type="text" name="user${userCounter}Username" value="${user.username}" disabled readonly />
				<div class="user1Username">
					<hr>
					<label>Email:</label>
					<input type="email" name="user${userCounter}Email" value="${user.email}" disabled readonly />
					<label>Age:</label>
					<input type="email" name="user${userCounter}Age" value="${user.age}" disabled readonly />
				</div>
				
				<button>Show more</button>`

        userCounter++;
        profileDiv.classList.add("profile");
        mainField.appendChild(profileDiv);

        let hiddenInfoDiv = profileDiv.querySelector(".user1Username");
        hiddenInfoDiv.style.display = "none";

        let showMoreBtn = profileDiv.querySelector("button");
        let lockRadioBtn = profileDiv.querySelector('input[value="lock"]');
        let unlockRadioBtn = profileDiv.querySelector('input[value="unlock"]');

        //console.log(lockRadioBtn);
        showMoreBtn.addEventListener("click", showOrHideInfo);

        function showOrHideInfo() {
            if(!unlockRadioBtn.checked){
                return;
            }

            if(showMoreBtn.textContent === "Show more"){
                hiddenInfoDiv.style.display = "block";
                showMoreBtn.textContent = "Hide it";
            } else if(showMoreBtn.textContent === "Hide it"){
                hiddenInfoDiv.style.display = "none";
                showMoreBtn.textContent = "Show more";
            }
        }
    });
}