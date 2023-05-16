using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;
using ProniaTemplate.Models;

namespace ProniaTemplate.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class TagController : Controller
    {
        private readonly ProniaDbContext _context;

        public TagController(ProniaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Tag> tag = _context.Tags.ToList();
            return View(tag);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Tag tag)
        {
            if (!ModelState.IsValid) return View();

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Tag tag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == id);
            if (tag == null) return NotFound();

            return View(tag);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Tag newtag)
        {
            if (id == null || id < 1) return BadRequest();

            Tag tag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == id);
            if (tag == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View(tag);
            }
            if (tag.Name == newtag.Name)
            {
                return RedirectToAction(nameof(Index));
            }

            bool result = await _context.Categories
                .AnyAsync(c => c.Name.Trim().ToLower() == tag.Name.Trim().ToLower());
            if (result)
            {
                ModelState.AddModelError("Name", "Bu adli tag artiq yaradilib");
                return View(tag);
            }

            tag.Name = newtag.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Tag tag = await _context.Tags.FirstOrDefaultAsync(c => c.Id == id);
            if (tag == null) return NotFound();

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
