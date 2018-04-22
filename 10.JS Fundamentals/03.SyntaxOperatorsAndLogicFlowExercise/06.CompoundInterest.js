function compoundInterest(input){
    let sum = input[0];
    let interestRate = input[1] / 100;
    let frequency = 12 / input[2];
    let years =  input[3];

    let f = sum * Math.pow((1 + interestRate / frequency), frequency * years);
   
    console.log(f.toFixed(2));
}

compoundInterest([1500, 4.3, 3, 6]);
compoundInterest([100000, 5, 12, 25]);
