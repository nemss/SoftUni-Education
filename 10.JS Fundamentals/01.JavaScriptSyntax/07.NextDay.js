function nextDay(year, month, day){
    let date = new Date(year, month - 1, day);
    date.setTime(date.getTime() + (24 * 60 * 60 * 1000));

    return date.getFullYear() + "-" +
    (date.getMonth() + 1) + '-' +
    date.getDate();
}

console.log(nextDay(2016, 9, 29))