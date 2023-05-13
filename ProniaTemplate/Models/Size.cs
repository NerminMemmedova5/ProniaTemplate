namespace ProniaTemplate.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Sizes { get; set; } //Name olmalidir 

        List<ProductSize> ProductSizes { get; set; }


        
    }
}
