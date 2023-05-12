namespace ProniaTemplate.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
