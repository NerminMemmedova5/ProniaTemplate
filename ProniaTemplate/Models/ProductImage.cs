﻿namespace ProniaTemplate.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool? IsMain { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
    }
}