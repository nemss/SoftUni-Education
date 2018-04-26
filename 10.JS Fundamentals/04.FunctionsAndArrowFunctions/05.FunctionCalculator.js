function calculator(a, b, operation){
    let add  = (x, y) => x + y;
    let subtract = (x, y) => x - y;
    let multiply = (x, y) => x * y;
    let devide = (x, y) => x / y;

    switch(operation){
        case '+': console.log(add(a, b));
        break;
        case '-': console.log(subtract(a, b));
        break;
        case '*': console.log(multiply(a, b));
        break;
        case '/': console.log(devide(a, b));
        break;
    }
}

calculator(1, 2, '+');
calculator(4, 2, '-');
calculator(4, 2, '/');
calculator(4, 2, '*');