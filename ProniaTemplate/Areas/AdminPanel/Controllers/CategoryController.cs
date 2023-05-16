using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;
using ProniaTemplate.Models;

namespace ProniaTemplate.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly ProniaDbContext _context;

        public CategoryController(ProniaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View();

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int?id,Category newcategory)
        {
            if (id == null || id < 1) return BadRequest();

            Category ex = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (ex == null) return NotFound();

            if (!ModelState.IsValid)
            { 
            return View(ex);
            }

           

            bool result = await _context.Categories
                .AnyAsync(c => c.Name.Trim().ToLower() == newcategory.Name.Trim().ToLower() && c.Id!=ex.Id);
            if (result)
            {
                ModelState.AddModelError("Name", "Bu adli category artiq yaradilib");
                return View(ex);
            }

            ex.Name = newcategory.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
