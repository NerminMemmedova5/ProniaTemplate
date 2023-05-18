using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaTemplate.Models
{
    public class Slide
    {
        [Required(ErrorMessage = "Title bos ola bilmez")]
        [MaxLength(45,ErrorMessage ="title 35 den uzun ola bilmez")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int Order { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }    
    }
}
