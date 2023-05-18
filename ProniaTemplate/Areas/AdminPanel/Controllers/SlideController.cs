using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;
using ProniaTemplate.Models;

namespace ProniaTemplate.Areas.AdminPanel.Controllers
{
        [Area("AdminPanel")]
    public class SlideController : Controller
    {
       
            private readonly ProniaDbContext _context;
            private readonly IWebHostEnvironment _env;

            public SlideController(ProniaDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }

            public IActionResult Index()
            {
                List<Slide> sliders = _context.Slides.ToList();
                return View(sliders);
            }

            public IActionResult Create()
            {
                return View();

            }

            [HttpPost]
            public async Task<IActionResult> Create(Slide slider)
            {

                if (!ModelState.IsValid) return View();
                if (slider == null)
                {
                    ModelState.AddModelError("Photo", "Sekil secin");
                    return View();
                }

                if (!slider.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi image olamilidir ");
                    return View();
                }
                if (slider.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu odemir");
                    return View();
                }

                var fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
                slider.Image = fileName;

                string path = Path.Combine(_env.WebRootPath, "upload/slide", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await slider.Photo.CopyToAsync(stream);
                }
                await _context.Slides.AddAsync(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            public async Task<IActionResult> Update(int id)
            {
                if (id == null && id < 1) return View();

                Slide slider = await _context.Slides.FirstOrDefaultAsync(s => s.Id == id);

                if (slider == null) return NotFound();

                return View(slider);

            }

            [HttpPost]
            public async Task<IActionResult> Update(Slide slider)
            {
                if (!ModelState.IsValid) return View();

            Slide exit = await _context.Slides.FirstOrDefaultAsync(s => s.Id == slider.Id);

                if (exit == null) return NotFound();

                if (slider.Photo != null)
                {
                    if (!slider.Photo.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("Photo", "Sekil tipi image olamilidir ");
                        return View();
                    }
                    if (slider.Photo.Length / 1024 > 200)
                    {
                        ModelState.AddModelError("Photo", "Olcu odemir");
                        return View();
                    }
                }

                string oldPath = Path.Combine(_env.WebRootPath, "upload/slide", exit.Image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                var fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;

                exit.Image = fileName;

                string path = Path.Combine(_env.WebRootPath, "upload/slide", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await slider.Photo.CopyToAsync(stream);
                }

                exit.Title = slider.Title;
                exit.Description = slider.Description;
                exit.SubTitle = slider.SubTitle;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Delete(int id)
            {
                Slide slider = await _context.Slides.FirstOrDefaultAsync(slider => slider.Id == id);

            if (slider == null) return NotFound();

                string oldPath = Path.Combine(_env.WebRootPath, "upload/slide", slider.Image);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                _context.Slides.Remove(slider);

                await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            }
        }
    }

