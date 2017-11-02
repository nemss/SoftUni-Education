using _1.Logger.Enums;

namespace _1.Logger.Interfaces
{
    public interface IAppender
    {
        void Append(ReportLevel reportLevel, string date, string msg);

        ReportLevel LevelOfThreshold { get; set; }
    }
}