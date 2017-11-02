namespace SimpleMvc.App.Controllers
{
    using BindingModels;
    using Data;
    using Domain;
    using Framework.Attributes.Methods;
    using Framework.Contracts;
    using Framework.Contracts.Generics;
    using Framework.Controllers;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersController : Controller
    {
        private SimpleMvcDbContext db = new SimpleMvcDbContext();

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };

            using (this.db)
            {
                this.db.Users.Add(user);
                this.db.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> usernames;

            using (this.db)
            {
                usernames = this.db.Users.Select(u => u.Username).ToList();
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Username = usernames
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == id);

            var viewModel = new UserProfileViewModel()
            {
                UserId = user.Id,
                Username = user.Username,
                Notes = user.Notes.Select(n => new NoteViewModel
                {
                    Title = n.Title,
                    Content = n.Content
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (db)
            {
                var user = db.Users.Find(model.UserId);
                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                db.SaveChanges();
            }
            return Profile(model.UserId);
        }
    }
}