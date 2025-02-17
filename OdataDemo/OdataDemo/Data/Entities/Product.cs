using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdataDemo.Data.Entities
{
    public class Category
    {
        [Key] // Đánh dấu khóa chính
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Navigation Property: Một Category có nhiều Product
        public ICollection<Product> Products { get; set; }
    }
    
    public class Product
    {
        [Key] // Đánh dấu khóa chính
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string Brand { get; set; }

        public decimal Cost { get; set; }

        public string Type { get; set; }

        public string ImageName { get; set; }

        // Khóa ngoại liên kết đến Category
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        // Navigation Property: Một Product thuộc về một Category
        public Category Category { get; set; }
    }
}