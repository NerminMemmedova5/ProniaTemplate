using Microsoft.AspNetCore.Mvc;
using ProniaTemplate.Models;
using ProniaTemplate.ViewModels;

namespace ProniaTemplate.Controllers
{
    public class HomeController : Controller
    {
        List<Home> Homes;
        List<Products> Products;
        public HomeController()
        {
            Homes = new List<Home>
            {
                new Home
                {
                    Id=1,
                    Name="Jale",
                    Surname="Eliyeva",
                    Position="HR",
                    Description="Lorem ipsum dolor sit amet,  ut labore et dolore. magna",
                    Image="1--1rnu4p.png"

                },
                 new Home
                {
                    Id=2,
                    Name="Zaur",
                    Surname="Eliyev",
                    Position="Software Developer",
                    Description="Lorem ipsum dolor sit amet",
                     Image="2.png"
                },
                  new Home
                {
                    Id=3,
                    Name="Nermin",
                    Surname="Memmedova",
                    Position="Master Student",
                    Description="Lorem ipsum dolor sit amet,  ut labore et dolore. magna",
                     Image="3.png"
                },
                   new Home
                {
                    Id=4,
                    Name="Ulker",
                    Surname="Agayeva",
                    Position="Doctor",
                    Description="Lorem ipsum dolor sit amet,  ut labore et dolore. magna",
                     Image="1--1rnu4p.png"
                },
            };
        }
       
        public IActionResult Index()
        {
            Products = new List<Products>
            {
                new Products
                {
                    Id=1,
                    Name="Kaktus",
                    Price=35.2m
                },
                new Products
                {
                    Id=2,
                    Name="Lily",
                    Price=10.2m
                },
                new Products
                {
                    Id=3,
                    Name="Orchid",
                    Price=95.1m
                },
                new Products
                {
                    Id=4,
                    Name="Bouquet",
                    Price=18.1m
                },
                new Products
                {
                    Id=5,
                    Name="Daisy",
                    Price=46m
                },
                new Products
                {
                    Id=6,
                    Name="Gardenia",
                    Price=82.7m
                },
                 new Products
                {
                    Id=7,
                    Name="Poppy",
                    Price=59m
                },
                  new Products
                {
                    Id=8,
                    Name="Aster",
                    Price=32.7m
                },
            };

            HomeViewModel viewModel = new HomeViewModel
            {
                Homes = Homes,
                Products=Products
            };
            return View(viewModel);
        }
    }
}
