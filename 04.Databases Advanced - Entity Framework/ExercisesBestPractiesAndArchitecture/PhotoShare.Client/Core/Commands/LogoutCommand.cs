using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand
    {
        public string Execute(string[] data)
        {
            if(!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("You shold log in first in order to logout!");
            }
            User user = AuthenticationManager.GetCurentUser();
            AuthenticationManager.Logout();

            return $"User {user.Username} successfully logged out!";
        }
    }
}
