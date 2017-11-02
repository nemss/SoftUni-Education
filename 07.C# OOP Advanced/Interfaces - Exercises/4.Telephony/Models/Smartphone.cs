using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.Telephony.Models
{
    public class Smartphone : ISmartphone, IBrawzing
    {
        public string Call(List<string> telephoneList)
        {
            var sb = new StringBuilder();
            var pattern = @"([A-za-z]+)";
            var regex = new Regex(pattern);
            foreach (var telphone in telephoneList)
            {
                if (!regex.IsMatch(telphone))
                {
                    sb.AppendLine($"Calling... {telphone}");
                }
                else
                {
                    sb.AppendLine("Invalid number!");
                }
            }

            return sb.ToString().Trim();
        }

        public string BrowseInTheInterner(List<string> linksList)
        {
            var pattern = @"[0-9]+";
            var regex = new Regex(pattern);
            var sb = new StringBuilder();

            foreach (var link in linksList)
            {
                if (!regex.IsMatch(link))
                {
                    sb.AppendLine($"Browsing: {link}!");
                }
                else
                {
                    sb.AppendLine("Invalid URL!");
                }
            }

            return sb.ToString().Trim();
        }
    }
}