using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;
using ProniaTemplate.Models;
using ProniaTemplate.ViewModels;

namespace ProniaTemplate.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProniaDbContext _dbContext;

        public ShopController(ProniaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Details()
        {

          


            return View();


            
        }
    }
}
