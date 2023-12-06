function attachEventsListeners() {
    let days = document.querySelector("#days");
    let daysBtn = document.querySelector("#daysBtn");
    let hours = document.querySelector("#hours");
    let hoursBtn = document.querySelector("#hoursBtn");
    let minutes = document.querySelector("#minutes");
    let minutesBtn = document.querySelector("#minutesBtn");
    let seconds = document.querySelector("#seconds");
    let secondsBtn = document.querySelector("#secondsBtn");

    
    daysBtn.addEventListener("click", daysConvert);
    hoursBtn.addEventListener("click", hoursConvert);
    minutesBtn.addEventListener("click", minutesConvert);
    secondsBtn.addEventListener("click", secondsConvert);

    function daysConvert(e) {
        hours.value = days.value * 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;
    }
    function hoursConvert(e) {
        days.value = hours.value / 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;
    }
    function minutesConvert(e) {
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;
        seconds.value = minutes.value * 60;
    }
    function secondsConvert(e) {
        minutes.value = seconds.value / 60;
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;
    }
}