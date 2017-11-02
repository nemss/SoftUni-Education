using System;

namespace CreateUser.Models
{
    internal class PasswordAttribute : Attribute
    {
        public object SholdContainUppercase;
        public bool ShouldContainLowercase;
    }
}