window.addEventListener("load", solve);

function solve() {
  let nameInputElement = document.getElementById("student");
  let universityInputElement = document.getElementById("university");
  let scoreInputElement = document.getElementById("score");
  let nextBtn = document.getElementById("next-btn");

  let studentsPreviewUl = document.getElementById("preview-list");
  let studentsCandidatesUl = document.getElementById("candidates-list");

  nextBtn.addEventListener("click", getInfo);


  function getInfo() {
    let name = nameInputElement.value;
    let university = universityInputElement.value;
    let score = scoreInputElement.value;

    let isInfoValid = name !== "" && university !== "" && score !== "";

    if (isInfoValid) {

      let liElement = document.createElement("li");
      liElement.classList.add("application");

      let articleElement = document.createElement("article");

      let nameElement = document.createElement("h4");
      nameElement.textContent = name;
      articleElement.appendChild(nameElement);

      let universityElement = document.createElement("p");
      universityElement.textContent = `University: ${university}`;
      articleElement.appendChild(universityElement);

      let scoreElement = document.createElement("p");
      scoreElement.textContent = `Score: ${score}`;
      articleElement.appendChild(scoreElement);

      liElement.appendChild(articleElement);

      editBtn = document.createElement("button");
      editBtn.classList.add("action-btn", "edit");
      editBtn.textContent = "edit";
      liElement.appendChild(editBtn);

      applyBtn = document.createElement("button");
      applyBtn.classList.add("action-btn", "apply");
      applyBtn.textContent = "apply";
      liElement.appendChild(applyBtn);

      studentsPreviewUl.appendChild(liElement);

      nextBtn.disabled = true;

      nameInputElement.value = "";
      universityInputElement.value = "";
      scoreInputElement.value = "";
    }

    editBtn.addEventListener("click", editInfo);
    applyBtn.addEventListener("click", apply);
  }

  function editInfo(e) {
    let targetElement = e.currentTarget;
    let liElement = targetElement.parentNode;
    let studentInfo = liElement.querySelector("article").children;

    let studentName = studentInfo[0].textContent;
    let studentUniversityTokens = studentInfo[1].textContent.split(": ");
    let studentScoreTokens = studentInfo[2].textContent.split(": ");

    nameInputElement.value = studentName;
    universityInputElement.value = studentUniversityTokens[1];
    scoreInputElement.value = studentScoreTokens[1];

    studentsPreviewUl.removeChild(liElement);
    nextBtn.disabled = false;
  }

  function apply(e) {
    let targetElement = e.currentTarget;
    let liElement = targetElement.parentNode;
    let [editBtn, applyBtn] = liElement.getElementsByTagName("button");
    
    liElement.removeChild(editBtn);
    liElement.removeChild(applyBtn);

    studentsCandidatesUl.appendChild(liElement);
    studentsPreviewUl.removeChild(liElement);

    nextBtn.disabled = false;
  }
}
