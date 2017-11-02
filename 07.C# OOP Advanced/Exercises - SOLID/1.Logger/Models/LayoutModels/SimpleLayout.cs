namespace _1.Logger.Models.LayoutModels
{
    using _1.Logger.Enums;
    using _1.Logger.Interfaces;

    public class SimpleLayout : ILayout

    {
        public string Formatting(ReportLevel reportLevel, string date, string msg)
        {
            return $"{date} - {reportLevel.ToString().ToUpper()} - {msg}";
        }
    }
}