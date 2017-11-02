using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeeklyEntry(string day, string notes)
    {
        Enum.TryParse(day, out this.weekDay);
        this.Notes = notes;
    }

    private WeekDay weekDay;
    public WeekDay WeekDay => this.weekDay;
    public string Notes { get; protected set; }

    public override string ToString()
    {
        return $"{this.WeekDay} - {this.Notes}";
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var weekDayComparison = weekDay.CompareTo(other.weekDay);
        if (weekDayComparison != 0) return weekDayComparison;
        return string.Compare(Notes, other.Notes, StringComparison.Ordinal);
    }
}