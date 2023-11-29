function moviesSolve(input){

    let moviesArr = [];

    input.forEach(element => {
        if (element.includes("addMovie")){
            let movieInfo = element.split("addMovie ");
            let movieName = movieInfo[1];
            moviesArr.push({name:movieName});
        }
        else if(element.includes("directedBy")){
            let [movie, director] = element.split(" directedBy ");

            let searchedMovie = moviesArr.find(m => m.name === movie);

            if (searchedMovie){
                searchedMovie["director"] = director;
            }
        } else if(element.includes("onDate")){
            let [movie, date] = element.split(" onDate ");

            let searchedMovie = moviesArr.find(m => m.name === movie);

            if (searchedMovie){
                searchedMovie["date"] = date;
            }
        }
    });

    moviesArr.forEach(m => {
        if (m.name && m.director && m.date){
            console.log(JSON.stringify(m));
        }
    });
}

moviesSolve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);