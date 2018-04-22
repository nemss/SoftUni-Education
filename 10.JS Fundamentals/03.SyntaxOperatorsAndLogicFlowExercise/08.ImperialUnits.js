function imperialUnits(number){
    let feet = Math.floor(number / 12);
    let inches = number % 12;

    console.log(`${feet}'-${inches}"`)
}

imperialUnits(36);
imperialUnits(55);
imperialUnits(11);