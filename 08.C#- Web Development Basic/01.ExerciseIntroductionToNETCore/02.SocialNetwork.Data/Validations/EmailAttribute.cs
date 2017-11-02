namespace _02.SocialNetwork.Data.Validations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class EmailAttribute : ValidationAttribute
    {
        public EmailAttribute()
        {
            this.ErrorMessage = "Email is not invalid.";
        }

        public override bool IsValid(object value)
        {
            var email = value as string;

            if (email == null)
            {
                return true;
            }

            return email.Contains("@");
        }
    }
}
