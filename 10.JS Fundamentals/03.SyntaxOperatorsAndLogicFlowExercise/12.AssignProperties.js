function assignProperties(data){
    let propertyNameFirst = data[0];
    let propertyNameSecond = data[2];
    let propertyNameThird = data[4];

    let valueFirst = data[1];
    let valueSecond = data[3];
    let valueThird = data[5];

    let obj = new Object();
    obj[propertyNameFirst] = valueFirst;
    obj[propertyNameSecond]  = valueSecond;
    obj[propertyNameThird]  = valueThird;

    return obj;
}

console.log(assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male']));