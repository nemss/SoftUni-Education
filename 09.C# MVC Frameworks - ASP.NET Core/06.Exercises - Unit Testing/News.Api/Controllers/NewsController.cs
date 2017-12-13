namespace News.Api.Controllers
{
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Interfaces;
    using System.Threading.Tasks;

    using static WebConstants;

    public class NewsController : BaseController
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

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var newss = await this.news.FindById(id);

            if (newss == null)
            {
                return NotFound();
            }

            var newsId = await this.news.Delete(id);

            return Ok(newsId);
        }

        [HttpPut(WithId)]
        public async Task<IActionResult> Put(int id, [FromBody] NewsPutServiceModel model)
        {
            var success = await this.news.Edit(id, model.Title, model.Content, model.PusblishDate);

            if (!success)
            {
                return BadRequest("Error!");
            }

            return Ok(id);
        }

    }
}
