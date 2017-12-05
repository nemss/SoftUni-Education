namespace BookShop.Api.Controllers
{
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Models.Categories;
    using Services.Interfaces;
    using System.Threading.Tasks;
    using static WebConstants;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        [HttpGet]
        public async Task<IActionResult> All()
            => Ok(await this.categories.All());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryRequestModel model)
        {
            if (await this.categories.Exists(model.Name))
            {
                return BadRequest("Category already exist!!!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var id = await this.categories.Create(model.Name);

            return Ok(id);
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.categories.FindById(id));

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await this.categories.FindById(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryId = await this.categories.Delete(id);

            return Ok(categoryId);
        }

        [HttpPut(WebConstants.WithId)]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryPutServiceModel model)
        {
            var success = await this.categories.Edit(id, model.Name);

            if (!success)
            {
                return BadRequest("Error!!!");
            }

            return Ok(id);
        }
    }
}