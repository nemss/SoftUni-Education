function square(squareSize){
    let middleLine = Math.ceil(squareSize / 2);
 
    for (let i = 0; i < (middleLine * 2) - 1 ; i++) {
        if (i === 0 || i === (middleLine * 2) - 2 || i === middleLine - 1) {
            console.log('+' + '-'.repeat(squareSize - 2) + '+' +'-'.repeat(squareSize - 2) + '+');
        } else {
            console.log('|' + ' '.repeat(squareSize - 2) + '|' + ' '.repeat(squareSize - 2) + '|');
        }
    }
}

square(6);

