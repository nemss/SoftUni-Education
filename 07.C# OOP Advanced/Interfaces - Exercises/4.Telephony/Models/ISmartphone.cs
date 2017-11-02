using System.Collections.Generic;

namespace _4.Telephony.Models
{
    public interface ISmartphone
    {
        string Call(List<string> telephoneList);
    }
}