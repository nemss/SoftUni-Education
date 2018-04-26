function dayOfWeek(day){
    let days = [ 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    let  dayNumberOfWeek  = days.indexOf(day);

    console.log(dayNumberOfWeek > - 1 ? dayNumberOfWeek + 1 : 'error');
}

dayOfWeek('Monday');