using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using RestaurantManagement.Models.Dtos;
using RestaurantManagement.Reposetories.IReposetory;
using RestaurantManagement.Reposetories.Reposetory;
using RestaurantManagement.Servisies;

namespace RestaurantManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryReposetory _categoryReposetory;
        private readonly IPdfExportService _pdfExportService;   



        public CategoryController(ICategoryReposetory categoryReposetory, IPdfExportService pdfExportService)
        {
            _categoryReposetory = categoryReposetory;
            _pdfExportService = pdfExportService;


        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateEmailWithMilkitDto categoryDto)
        {
           var category = await _categoryReposetory.CreateCategoryAsync(categoryDto);
            if (category == null)
            {
                return BadRequest("Category creation failed.");
            }
            return Ok(category);
        }
        [HttpGet("pdf")]
        public async Task<IActionResult> GetPdf()
        {
            var data = await _categoryReposetory.GetAllAsync();
            if (data == null || !data.Any())
                throw new Exception("No categories found.");
            var fileBytes = await _pdfExportService.ExportTableToPdfAsync(data, "Categories Report");
            return File(fileBytes, "application/pdf", "Categories.pdf");
        }



    }
}
