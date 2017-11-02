namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using PhotoShare.Models;

    public class MakeFriendsCommand
    {
        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            string firstUsername = data[0];
            string secondUsername = data[1];


            if (!IsUsernameExisting(firstUsername) || !IsUsernameExisting(secondUsername))
            {
                throw new ArgumentException($"Any of the users do not exist.");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                User u = context.Users.SingleOrDefault(us => us.Username == firstUsername);
                User u1 = context.Users.SingleOrDefault(us => us.Username == secondUsername);

                u.Friends.Add(u1);
                u1.Friends.Add(u);
                context.SaveChanges();
            }



                return $"Friend {secondUsername} added to {firstUsername}";
        }

        private bool IsUsernameExisting(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }
    }
}
