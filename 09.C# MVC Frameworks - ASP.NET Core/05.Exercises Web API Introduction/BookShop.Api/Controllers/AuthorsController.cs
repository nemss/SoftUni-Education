namespace BookShop.Api.Controllers
{
    using System.Threading.Tasks;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Interfaces;
    using static WebConstants;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authors;

        public AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.authors.Details(id));

        [HttpPost]
        public async Task<IActionResult> Post(AuthorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = await this.authors.Create(model.FirstName, model.LastName);

            return Ok();
        }
    }
}
