namespace Library.Client.Utilities
{
    using System;
    public class Constants
    {
        public const int MinUsernameLength = 3;
        public const int MaxUsernameLength = 25;

        public const int MaxFirstNameLength = 25;

        public const int MaxLastNameLength = 25;

        public const int MinPasswordLength = 6;
        public const int MaxPasswordLength = 30;

        public static class ErrorMessages
        {
            // Common error messages.
            public const string InvalidArgumentsCount = "Invalid arguments count!";

            public const string LogoutFirst = "You should logout first!";
            public const string LoginFirst = "You should login first!";

            public const string NotAllowed = "Not allowed!";

            public const string BookNotFound = "Book {0} not found!";
            public const string UserNotFound = "User {0} not found!";
            public const string AuthortNotFound = "Author {0} not found!";

            // User error messages.
            public const string UsernameNotValid = "Username {0} not valid!";
            public const string PasswordNotValid = "Password {0} not valid!";
            public const string PasswordDoesNotMatch = "Passwords do not match!";
            public const string AgeNotValid = "Age not valid!";
            public const string GenderNotValid = "Gender should be either “Male” or “Female”!";
            public const string RoleNotValid = "Role should be either “Admin” or “User”!";
            public const string UsernameIsTaken = "Username {0} is already taken!";
            public const string RoleIsTheSame = "Role {0} is already exists!";
            public const string UserOrPasswordIsInvalid = "Invalid username or password!";

            // Book error messages.
            public const string BookExists = "Book {0} exists!";
        }
    }
}
