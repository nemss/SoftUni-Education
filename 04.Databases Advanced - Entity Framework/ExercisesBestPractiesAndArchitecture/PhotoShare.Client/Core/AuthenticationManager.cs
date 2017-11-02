using PhotoShare.Models;
using System;

namespace PhotoShare.Client.Core
{
    
   public static class AuthenticationManager
    {
        private static User currentUser;

        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public static void Logout()
        {
            if(!IsAuthenticated())
            {
                throw new InvalidOperationException("You should login.");
            }

            currentUser = null;
        }

        public static void Login(User user)
        {
            if (IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout.");
            }

            currentUser = user;
        }
        public static User GetCurentUser()
        {
            return currentUser;
        }
    }
}
