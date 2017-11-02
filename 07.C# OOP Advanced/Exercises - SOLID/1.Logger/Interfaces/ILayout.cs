namespace _1.Logger.Interfaces
{
    using _1.Logger.Enums;

    public interface ILayout
    {
        string Formatting(ReportLevel reportLevel, string date, string msg);
    }
}