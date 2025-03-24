using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }

        public int ProductEntityId { get; set; }

        public string ReviewText { get; set; }

        public decimal ReviewRating { get; set; }

        public DateTime ReviewDate { get; set; }

        public string UserEmail { get; set; }
    }
}
