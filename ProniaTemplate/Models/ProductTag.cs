namespace ProniaTemplate.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
