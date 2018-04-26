function printTriangleOfStars(n){
    for(let i = 1; i <= n; i++){
        console.log('*'.repeat(i));
    }

    for(let j = n - 1; j > 0; j--){
        console.log('*'.repeat(j));
    }
}

printTriangleOfStars(3);