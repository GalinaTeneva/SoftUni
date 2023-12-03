function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   class Reataurant{
      constructor(name, bestSalary, avgSalary, workersArr){
         this.name = name;
         this.bestSalary = bestSalary;
         this.avgSalary = avgSalary;
         this.workersArr = workersArr;
      }
   }

   function onClick () {
      let input = document.getElementsByTagName("textarea")[0].value;

      let restaurantsArr = [];

      let inputArr = JSON.parse(input);

      for(let i = 0; i < inputArr.length; i++){
         let currInfo =  inputArr[i].split(" - ");
         let currName = currInfo[0];
         let currWorkersArr = currInfo[1].split(", ");
         let restaurantBestSalary = 0;
         let restaurantSumSalary = 0;
         let currRestaurantWorkers = {};
         
         for(let j = 0; j < currWorkersArr.length; j++){
            let currWorkerInfo = currWorkersArr[j].split(" ");
            let currWorkerName = currWorkerInfo[0];
            let currWorkerSalary = Number(currWorkerInfo[1]);
            
            if(restaurantBestSalary < currWorkerSalary){
               restaurantBestSalary = currWorkerSalary;
            }
            
            restaurantSumSalary += currWorkerSalary;
            
            currRestaurantWorkers[currWorkerName] = currWorkerSalary;
         }
         
         let restaurantAvgSalary = restaurantSumSalary / currWorkersArr.length;
         restaurantsArr.push({currName, restaurantBestSalary, restaurantAvgSalary, currRestaurantWorkers});
      }

      let sortedRestaurants = restaurantsArr.sort((a, b) => b.restaurantAvgSalary - a.restaurantAvgSalary);
      let bestRestaurant = sortedRestaurants[0];
      
      let bestRestaurantOutput = `Name: ${bestRestaurant.currName} Average Salary: ${bestRestaurant.restaurantAvgSalary.toFixed(2)} Best Salary: ${bestRestaurant.restaurantBestSalary.toFixed(2)}`;
      document.querySelector("#outputs p").textContent = bestRestaurantOutput;

      let workersOutputArr = [];
      for (const worker in bestRestaurant.currRestaurantWorkers) {
         workersOutputArr.push(`Name: ${worker} With Salary: ${bestRestaurant.currRestaurantWorkers[worker]}`);
      }
      document.querySelector("#workers p").textContent = workersOutputArr.join(" ");
   }
}