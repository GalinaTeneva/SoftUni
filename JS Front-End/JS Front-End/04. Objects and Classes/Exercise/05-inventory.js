function createHeroesRegister(input){
    class Hero{
        constructor(name, level, items){
            this.name = name;
            this.level = level;
            this.items = items;
        }
    }

    let heroesRegister = [];

    for (let i = 0; i < input.length; i++) {
        let currHeroInfo = input[i].split(" / ");
        let heroName = currHeroInfo[0];
        let heroLevel = Number(currHeroInfo[1]);
        let heroItems = currHeroInfo[2];
        let currHero = new Hero(heroName, heroLevel, heroItems);
        heroesRegister.push(currHero);
    }

    heroesRegister.sort((a, b) => a.level - b.level);

    heroesRegister.forEach(h => {
        console.log(`Hero: ${h.name}`);
        console.log(`level => ${h.level}`);
        console.log(`items => ${h.items}`)
    });
}

createHeroesRegister([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]);