'use strict';

function projectCreation(input) {

    let hoursForOneProject = 3;
    let name = input[0];
    let projectsCount = input[1];

    let totalHours = hoursForOneProject * projectsCount;

    console.log(`The architect ${name} will need ${totalHours} hours to complete ${projectsCount} project/s.`);
}

projectCreation(["George ", "4 "]);
