using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryStore.Backend.DAL.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryDescription { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
