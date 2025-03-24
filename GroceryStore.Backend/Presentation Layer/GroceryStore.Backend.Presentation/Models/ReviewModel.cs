using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Models
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }

        public int ProductEntityId { get; set; }

        public string ReviewText { get; set; }

        public decimal ReviewRating { get; set; }

        public DateTime ReviewDate { get; set; }

        public string UserEmail { get; set; }
    }
}
