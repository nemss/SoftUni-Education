namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Linq;

    public class PrintFriendsListCommand 
    {
        // PrintFriendsList <username>
        public string Execute(string[] data)
        {

            string username = data[0];

            User u = GetUserByUserName(username);

            if (u == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var listFriends = context.Users.SingleOrDefault(us => us.Username == username)
                    .Friends
                    .Select(s => s.Username).ToList();

                Console.WriteLine("Friends:"); 
                 
                if(listFriends.Count() == 0)
                {
                    return "No friends for this user";
                }

                Console.WriteLine("Friends:");

                foreach (var l in listFriends)
                {
                    Console.WriteLine($"{l}");
                }
            }

            return "Succsess";
            
        }
        public User GetUserByUserName(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

    }
}
