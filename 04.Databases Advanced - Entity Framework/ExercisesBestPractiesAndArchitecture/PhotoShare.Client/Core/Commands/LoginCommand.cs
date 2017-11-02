using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Models;

namespace PhotoShare.Client.Core.Commands
{
    public class LoginCommand
    {
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];

            if(AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if(!IsUserExisting(username, password))
            {
                throw new ArgumentException("Invalid username or password!");
            }

            AuthenticationManager.Login(GetUserByUsername(username));

            return $"User {username} successfully logged in!";
        }

        private User GetUserByUsername(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

        public bool IsUserExisting(string username, string password)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username && u.Password == password);
            }
        }
    }
}
