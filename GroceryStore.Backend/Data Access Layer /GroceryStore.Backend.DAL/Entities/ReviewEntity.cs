using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryStore.Backend.DAL.Entities
{
    public class ReviewEntity
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int ProductEntityId { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Required]
        [Range(1,5)]
        public decimal ReviewRating { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        [Required]
        public string UserEmail { get; set; }
    }
}
