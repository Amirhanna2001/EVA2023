using E_CommerceAPI.Dtos;
using E_CommerceAPI.Models;
using E_CommerceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _categoryServices.GetCategories());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            Category category = new() { Name = dto.Name };
            await _categoryServices.Add(category);

            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(byte id, [FromBody] CategoryDto dto)
        {
            Category category = await _categoryServices.GetCategory(id);

            if (category == null)
                return NotFound($"No Category found by ID = {id}");

            category.Name = dto.Name;

            _categoryServices.Update(category);

            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            Category category = await _categoryServices.GetCategory(id);

            if (category == null)
                return NotFound($"No Category found by ID = {id}");

            _categoryServices.Delete(category);

            return Ok(category);

        }
    }
}
