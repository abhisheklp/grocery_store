using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryStore.Backend.DAL.Entities
{
    public class CartEntity
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int ProductEntityId { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
