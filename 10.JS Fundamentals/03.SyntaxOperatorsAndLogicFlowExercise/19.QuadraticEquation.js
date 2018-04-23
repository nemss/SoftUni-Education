function quadraticEquation(input){
    let a = Number(input[0]);
    let b = Number(input[1]);
    let c = Number(input[2]);

    let descriminant = b ** 2 - 4 * a * c;

    if (descriminant > 0){
        let x1 = (-b + Math.sqrt(descriminant)) / (2 * a);
        let x2 = (-b - Math.sqrt(descriminant)) / (2 * a);

        console.log(Math.min(x1, x2));
        console.log(Math.max(x1, x2));
    } else if (descriminant === 0){
        console.log(-b / (2 * a));
    } else if (descriminant < 0){
        console.log('No');
    }     
}

quadraticEquation([6, 11, -35]);
quadraticEquation([1, -12, 36]);