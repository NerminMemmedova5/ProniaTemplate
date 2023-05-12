using Microsoft.EntityFrameworkCore;
using ProniaTemplate.Models;

namespace ProniaTemplate.DAL
{
    public class ProniaDbContext:DbContext
    {
        public ProniaDbContext(DbContextOptions<ProniaDbContext> options):base(options)
        {

        }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }

    }
}
