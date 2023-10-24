﻿namespace BusinessLogic.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? Discount { get; set; }

        public bool InStock { get; set; }

        public string? Description { get; set; }
    }
}
