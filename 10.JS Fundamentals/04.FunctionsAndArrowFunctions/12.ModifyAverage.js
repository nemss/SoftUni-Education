function modifyAverage(input) {
    let numberStr = String(input);
    
    let getAverage = (numStr) => numberStr.split('').map(Number).reduce((a, b) => a += b) / numberStr.length;

    while(getAverage(numberStr) <= 5) {
        numberStr += '9';
    }

    console.log(numberStr);
}


modifyAverage(101);