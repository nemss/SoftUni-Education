namespace TeamBuilder.App.Core
{
    using Models;
    using System;
    using Utilities;

    public class AuthenticationManager
    {
        private static User currentUser;

        public static void Login(User user)
        {
            if(IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            currentUser = user;
        }

        public static void Logout()
        {
            if(!IsAuthenticated())
            {
                throw new InvalidOperationException("You login first!");
            }
            currentUser = null;
        }

        public static void Authorize()
        {    
            if(currentUser == null)
            {
                throw new InvalidOperationException("You should login first!");
            }
        }

        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }
    }
}
