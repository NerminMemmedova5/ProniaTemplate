using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;
using ProniaTemplate.Models;
using System;

namespace ProniaTemplate.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class PersonController : Controller
    {
        private readonly ProniaDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PersonController(ProniaDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Person> person = _context.Persons.ToList();
            return View(person);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {

            if (!ModelState.IsValid) return View();
            if (person == null)
            {
                ModelState.AddModelError("Photo", "Sekil secin");
                return View();
            }

            if (!person.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "Sekil tipi image olamilidir ");
                return View();
            }
            if (person.Photo.Length / 1024 > 200)
            {
                ModelState.AddModelError("Photo", "Olcu odemir");
                return View();
            }

            var fileName = Guid.NewGuid().ToString() + "_" + person.Photo.FileName;
            person.Image = fileName;

            string path = Path.Combine(_env.WebRootPath, "upload/person", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await person.Photo.CopyToAsync(stream);
            }
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id)
        {
            if (id == null && id < 1) return View();

            Person person = await _context.Persons.FirstOrDefaultAsync(s => s.Id == id);

            if (person == null) return NotFound();

            return View(person);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Person person)
        {
            if (!ModelState.IsValid) return View();

            Person exit = await _context.Persons.FirstOrDefaultAsync(s => s.Id == person.Id);

            if (exit == null) return NotFound();

            if (person.Photo != null)
            {
                if (!person.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "Sekil tipi image olamilidir ");
                    return View();
                }
                if (person.Photo.Length / 1024 > 200)
                {
                    ModelState.AddModelError("Photo", "Olcu odemir");
                    return View();
                }
            }

            string oldPath = Path.Combine(_env.WebRootPath, "upload/person", exit.Image);

            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            var fileName = Guid.NewGuid().ToString() + "_" + person.Photo.FileName;

            exit.Image = fileName;

            string path = Path.Combine(_env.WebRootPath, "upload/person", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await person.Photo.CopyToAsync(stream);
            }

            exit.Name = person.Name;
            exit.Surname = person.Surname;
           

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Person person = await _context.Persons.FirstOrDefaultAsync(person => person.Id == id);

            if (person == null) return NotFound();

            string oldPath = Path.Combine(_env.WebRootPath, "upload/person", person.Image);

            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            _context.Persons.Remove(person);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
