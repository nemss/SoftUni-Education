function calendar([day, month, year]) {
    day = Number(day);
    month = Number(month);
    year = Number(year);

    let date = new Date(year, month - 1, day);
    let nextMonthDays = [];
    let prevMonthDays = [];
    let currentMonthDays = [];

    let currentMonth = new Date(date);
    currentMonth.setDate(1);
    let temp = new Date(currentMonth);
    temp.setMonth(currentMonth.getMonth() + 1);
    temp.setDate(0);
    let stop = temp.getDate();
    while (true) {
        currentMonthDays.push(new Date(currentMonth));
        if ((currentMonth.getDate() == stop))
            break;
        currentMonth.setDate(currentMonth.getDate() + 1);
    }

    let nextMonth = new Date(date);
    nextMonth.setMonth(nextMonth.getMonth() + 1);
    nextMonth.setDate(1);
    while (true) {
        if (nextMonth.getDay() == 0)
            break;
        nextMonthDays.push(new Date(nextMonth));
        nextMonth.setDate(nextMonth.getDate() + 1);
    };

    let prevMonth = new Date(date);
    prevMonth.setDate(0);
    while (true) {
        prevMonthDays.push(new Date(prevMonth));
        if (prevMonth.getDay() == 0)
            break;
        prevMonth.setDate(prevMonth.getDate() - 1);
    };
    prevMonthDays.reverse();

    let html = "<table>\n";

    html +=
        "<tr><th>Sun</th><th>Mon</th>" +
        "<th>Tue</th><th>Wed</th><th>Thu</th>" +
        "<th>Fri</th><th>Sat</th></tr>\n";
  
    let counter = 0;
    let flow = -1;
    let currentMonthLen = currentMonthDays.length;
    let prevMonthLen = prevMonthDays.length;
    let nextMonthLen = nextMonthDays.length;
    let boundary = currentMonthDays[0].getDay() == 0
        ? (currentMonthLen + nextMonthLen) / 7
        : (currentMonthLen + prevMonthLen + nextMonthLen) / 7;

    for (let row = 0; row < boundary; row++) {
        html += "  <tr>";

        for (let col = 0; col < 7; col++) {
         
            if (counter < prevMonthLen && flow == -1) {
                if (currentMonthDays[0].getDay() == 0) {
                    flow++;
                    counter = 0;
                    col--;
                    continue;
                }
                html += `<td class="prev-month">${prevMonthDays[counter].getDate()}</td>`;
            }
            if (counter == prevMonthLen && flow == -1 ||
                counter == currentMonthLen && flow == 0) {
                flow++;
                counter = 0;
            }
            if (counter < currentMonthLen && flow == 0) {
                if (currentMonthDays[counter].getDate() == day)
                    html += `<td class="today">${day}</td>`;
                else
                    html += `<td>${currentMonthDays[counter].getDate()}</td>`;
            }
            if (counter < nextMonthLen && flow == 1) {
                html += `<td class="next-month">${nextMonthDays[counter].getDate()}</td>`;
            }
            counter++;
        }

        html += "</tr>\n";
    }

    html += "</table>";
    return html;
}
console.log(calendar(['24','12','2012']));