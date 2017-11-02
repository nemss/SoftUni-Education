namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModifyUserCommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string username = data[0];
            string type = data[1];
            string value = data[2];
           

            User user = GetUserByUserName(username);

            if(user == null) 
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if(type.Equals("Password"))
            {
                if(!(value.Any(c => char.IsLower(c)) && value.Any(c => char.IsDigit(c))))
                {
                    throw new ArgumentException($"Value {value} not valid!\nInvalid password");
                }
                user.Password = value;
            }
            else if(type.Equals("BornTown"))
            {
                Town town = GetByTownName(value);

                if(town == null)
                {
                    throw new ArgumentException($"Town {town} not found!”");
                }

                user.BornTown = town;
            }
            else if(type.Equals("CurrentTown"))
            {
                Town town = GetByTownName(value);

                if (town == null)
                {
                    throw new ArgumentException($"Town {town} not found!”");
                }

                user.CurrentTown = town;
            }
            else
            {
                throw new ArgumentException($"Property {type} not supported!");
            }

            UpdateUser(user);

            return $"User {username} {type} is {value}.";
        }

        private Town GetByTownName(string townName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Towns.SingleOrDefault(t => t.Name == townName);
            }
        }

        private User GetUserByUserName(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

        public void UpdateUser(User user)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User userToUpdate = context.Users
                    .Include("BornTown")
                    .Include("CurrentTown")
                    .SingleOrDefault(u =>u.Id == user.Id);  

                if(userToUpdate != null)
                {
                if(user.Password != userToUpdate.Password)
                    {
                        userToUpdate.Password = user.Password;
                    } 

                if(user.BornTown != null && (userToUpdate.BornTown == null || user.BornTown.Id != userToUpdate.BornTown.Id))
                    {
                        userToUpdate.BornTown = context.Towns.Find(user.BornTown.Id);
                    }

                if (user.CurrentTown != null && (userToUpdate.CurrentTown == null || user.CurrentTown.Id != userToUpdate.CurrentTown.Id))
                    {
                        userToUpdate.CurrentTown = context.Towns.Find(user.CurrentTown.Id);
                    }
                context.SaveChanges();
                }
            }
        }
    }
}
