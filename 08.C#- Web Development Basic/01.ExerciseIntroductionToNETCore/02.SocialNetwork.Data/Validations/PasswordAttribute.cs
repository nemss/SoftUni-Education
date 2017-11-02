namespace _02.SocialNetwork.Data.Validations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PasswordAttribute : ValidationAttribute
    {
        private readonly char[] RequiredSymbols = new[]
            {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?'};

        public PasswordAttribute()
        {
            this.ErrorMessage = "Password is not valid.";
        }

        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null)
            {
                return true;
            }

            return password.Any(p =>
            char.IsLower(p)
            || char.IsUpper(p)
            || char.IsDigit(p)
            || this.RequiredSymbols.Contains(p));
        }
    }
}
