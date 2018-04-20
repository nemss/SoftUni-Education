function cone(r, h){
    let s = Math.sqrt(r * r + h * h);
    let volume = Math.PI * r * r  * h / 3;
    let area = Math.PI * r * (r + s);

    console.log("volume = " + volume);
    console.log("area = " + area);
}

cone(3, 5);