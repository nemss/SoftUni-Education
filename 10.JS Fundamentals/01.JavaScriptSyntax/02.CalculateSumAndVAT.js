function sumVat(numbers){
    let sum = 0;
    for(let number of numbers){
        sum += Number(number);
    }

    console.log("sum = " + sum);
    console.log("Vat = " + sum * 0.20);
    console.log("total = " + sum * 1.20);
}

sumVat([1.20, 2.60, 3.50])