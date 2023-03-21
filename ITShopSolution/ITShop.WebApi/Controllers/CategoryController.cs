using ITShop.Models.Entities;
using ITShop.Models.Requests;
using ITShop.WebApi.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Categories.ToListAsync();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryFormRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newCategory = new Category()
            {
                Id = 0,
                Name = request.Name,
                ParentId = request.ParentId
            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return Ok(newCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id không tồn tại");
            }

            var category = await _context.Categories.SingleOrDefaultAsync(x=>x.Id==id);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery]int id, CategoryFormRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id <= 0)
            {
                return BadRequest("Id không tồn tại");
            }

            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                category.Name = request.Name;
                category.ParentId = request.ParentId;
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int[] ids)
        {
            foreach (int id in ids)
            {
                var categories = _context.Categories.Where(x=>x.ParentId==id).ToArray();
                var category = _context.Categories.SingleOrDefault(x=>x.Id==id);
                if (category != null)
                {
                    _context.Categories.RemoveRange(categories);
                    _context.Categories.Remove(category);
                }
            }
            var result = await _context.SaveChangesAsync();
          return Ok("Xoá thành công " + result + " danh mục");
        }
    }
}
