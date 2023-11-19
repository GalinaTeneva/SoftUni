
function generateSchedule(input) {
    let scheduleArr = {};

    for (const item of input) {
        let [day, person] = item.split(" ");

        if (scheduleArr.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`)
        } else {
            scheduleArr[day] = person;
            console.log(`Scheduled for ${day}`);
        }
    }

    for (const key in scheduleArr){
        console.log(`${key} -> ${scheduleArr[key]}`)
    }
}

generateSchedule(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George']
);
