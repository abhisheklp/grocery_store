using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryStore.Backend.DAL.Entities
{
    public class ProductEntity
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductDescription { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        public decimal ProductDiscount { get; set; }

        public string ProductSpecification { get; set; }

        [Required]
        [RegularExpression(@"\.(jpg|png)$")]
        public string ProductImage { get; set; }

        [Required]
        public int CategoryEntityId { get; set; }

        public ICollection<CartEntity> CartItems { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
