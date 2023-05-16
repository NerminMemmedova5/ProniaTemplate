using ProniaTemplate.Models;

namespace ProniaTemplate.ViewModels
{
    public class HomeViewModel
    {
        public List<Person> Persons { get; set; }
        public List<Position> Positions { get; set; }
        public List<Product> Products { get; set; }
        public List<Slide> Slides { get; set; }
        public List<Product> RelatedProducts { get; set; }




    }
}
