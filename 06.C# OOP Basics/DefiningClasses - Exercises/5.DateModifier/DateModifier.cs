namespace _5.DateModifier
{
    using System;
    public class DateModifier
    {
        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }
        private string firstDate;
        private string secondDate;

        public string FirstDate
        {
            get { return this.firstDate; }
            set { this.firstDate = value; }
        }

        public string SecondDate
        {
            get { return this.secondDate; }
            set { this.secondDate = value; }
        }

        public void CalculateDifferenceBetweenTwoDates()
        {
            var parseDateTimeFirst = DateTime.Parse(this.FirstDate);
            var parseDateTimeSecond = DateTime.Parse(this.SecondDate);

            var result = (parseDateTimeFirst - parseDateTimeSecond).TotalDays;
            Console.WriteLine(Math.Abs(result));
        }
    }
}
