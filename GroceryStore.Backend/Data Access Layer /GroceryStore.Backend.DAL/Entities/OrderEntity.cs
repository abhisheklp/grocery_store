using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryStore.Backend.DAL.Entities
{
    public class OrderEntity
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public string OrderedItems { get; set; }

        [Required]
        public string OrderedQuantity { get; set; }

        [Required]
        public string AmountInItem { get; set; }

        [Required]
        public decimal OrderAmount { get; set; }
    }
}
