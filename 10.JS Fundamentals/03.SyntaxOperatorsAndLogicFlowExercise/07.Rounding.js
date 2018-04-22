function rounding(data){
    let number = Number(data[0]);
    let precision = Number(data[1]);

    if(precision > 15) precision = 15;

    let output = number.toFixed(precision);

    console.log(parseFloat(output));
}

rounding([3.1415926535897932384626433832795, 2])
rounding([10.5], 3)