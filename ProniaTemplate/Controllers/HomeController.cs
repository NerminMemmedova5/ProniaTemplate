﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaTemplate.DAL;
using ProniaTemplate.Models;
using ProniaTemplate.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace ProniaTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProniaDbContext _context; 

        public HomeController(ProniaDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
           
            
             List<Slide> Slides = _context.Slides.ToList();

            //_context.Products.AddRange(Products);
            //_context.SaveChanges();

            List<Products> Products = _context.Products.Include(p => p.Category).ToList();

            //_context.Positions.AddRange(Positions);
            //_context.SaveChanges();

            List<Position> Positions = _context.Positions.ToList();

            //_context.Persons.AddRange(Persons);
            //_context.SaveChanges();

            List<Person> Persons=_context.Persons.Include(p=>p.Position).ToList();

            HomeViewModel viewModel = new HomeViewModel
            {
                Persons = Persons,
                Positions=Positions,
                Products=Products,
                Slides=Slides
                
            };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Products products = _context.Products.Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
            if (products == null) return NotFound();


            return View(products);
        }
    }
}
