function distanceIn3D(input){
    let x0 = input[0], y0 = input[1], z0 = input[2],
        x1 = input[3], y1 = input[4], z1 = input[5];

    let distance = Math.sqrt(Math.pow(x1 - x0, 2) + Math.pow(y1 - y0, 2) + Math.pow(z1 - z0, 2));
    console.log(distance);
}

distanceIn3D([1, 1, 0, 5, 5, 0]);
distanceIn3D([3.5, 0, 1, 0, 2, -1]);