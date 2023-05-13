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
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        





    }
}
