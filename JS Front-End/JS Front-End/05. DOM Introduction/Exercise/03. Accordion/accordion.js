function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let buttonTextContent = button.textContent;
    
    if (buttonTextContent === "More"){
        document.getElementById("extra").style.display = "block";
        button.textContent = "Less";
    } else if (buttonTextContent === "Less"){
        document.getElementById("extra").style.display = "none";
        button.textContent = "More";
    }
}