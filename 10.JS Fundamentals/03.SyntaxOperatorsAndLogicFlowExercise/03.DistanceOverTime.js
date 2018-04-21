function distanceOverTime(input){
    let dist1 = (input[0]  * input[2]) / 3.6;
    let dist2 = (input[1] * input[2]) / 3.6;

    let delta = Math.abs(dist1 - dist2);

    console.log(delta);
}

distanceOverTime([0, 60, 3600]);
distanceOverTime([5, -5, 40]);

