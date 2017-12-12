namespace News.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using Models;

    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        [HttpGet]
        public async Task<IActionResult> All()
            => Ok(await this.news.All());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNewsRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var id = await this.news.Create(model.Title, model.Content, model.PusblishDate);

            return Ok(id);
        }

    }
}
