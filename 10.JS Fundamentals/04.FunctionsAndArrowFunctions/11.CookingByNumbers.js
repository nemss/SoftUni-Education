function cookingByNumbers (input) {
    let number = Number(input[0]);

    for (let i = 1; i <= 5; i++) {
        console.log(operations(input[i]));
    }

    function operations (operation) {
        switch (operation) {
            case 'chop': return  number /= 2;
            case 'dice': return  number = Math.sqrt(number);
            case 'spice': return number += 1;
            case 'bake': return number *= 3;
            case 'fillet': return number *= 0.8;
        }
    }
}

cookingByNumbers([32, 'chop', 'chop', 'chop', 'chop', 'chop']);
cookingByNumbers([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);