function fruitOrVegetable(input){
    switch(input){
        case 'banana':
        case 'kiwi':
        case 'apple':
        case 'cherry':
        case 'lemon':
        case 'grapes':
        case 'peach':
        console.log('fruit');
        break;

        case 'tomato':
        case 'cucumber':
        case 'pepper':
        case 'onion':
        case 'garlic':
        case 'parsley':
        console.log('vegetable');
        break;
        default:
        console.log('unknown');
    }
}

fruitOrVegetable('banana');