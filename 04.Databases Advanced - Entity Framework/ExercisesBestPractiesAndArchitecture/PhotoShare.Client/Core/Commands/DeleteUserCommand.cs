namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    public class DeleteUserCommand
    {
        // DeleteUser <username>
        public string Execute(string[] data)
        {
            string username = data[0];
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException($"User with {username} was not found!");
                }
                
                if(user.IsDeleted == true)
                {
                    throw new InvalidOperationException($"User {username} is already deleted!");
                }
                user.IsDeleted = true;
                context.SaveChanges();

                return $"User {username} was deleted from the database!";
            }
        }
    }
}
