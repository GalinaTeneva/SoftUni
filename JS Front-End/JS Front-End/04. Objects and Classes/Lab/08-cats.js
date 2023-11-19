function createCat(input) {
    class cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        };

        sayMeow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    let catsArr = [];

    for (let i = 0; i < input.length; i++) {
        let catInfo = input[i].split(" ");
        let name, age;
        [name, age] = [catInfo[0], catInfo[1]];
        catsArr.push(new cat(name, age));
    }

    for (const item of catsArr) {
        item.sayMeow();
    }
}


createCat(['Candy 1', 'Poppy 3', 'Nyx 2']);