function printSquareOfStars(n){

    for(let row = 1; row <= n; row++){
        printStars();
    }

    function printStars(count = n){
        console.log('* '.repeat(n).trim());
    }
}

printSquareOfStars(1)