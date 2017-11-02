namespace CreateUser
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CreateUser.Models;
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
        }

      public IDbSet<User> Users { get; set; }
    }
}