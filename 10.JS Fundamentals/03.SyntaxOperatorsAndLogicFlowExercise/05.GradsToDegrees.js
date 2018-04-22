function gradsToDegrees(grad){
    grad = grad % 400;
    var degree = grad * 0.9;
    let degreeOutput = degree < 0 ? degree += 360 : degree;
    console.log(degree)
    
}

gradsToDegrees(100);
gradsToDegrees(400);