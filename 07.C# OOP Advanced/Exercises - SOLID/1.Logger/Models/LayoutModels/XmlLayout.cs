namespace _1.Logger.Models.LayoutModels
{
    using _1.Logger.Enums;
    using _1.Logger.Interfaces;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Formatting(ReportLevel reportLevel, string date, string msg)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{date}</date>");
            sb.AppendLine($"    <level>{reportLevel.ToString().ToUpper()}</level>");
            sb.AppendLine($"    <message>{msg}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().Trim();
        }
    }
}