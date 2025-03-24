using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductQuantity { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal ProductDiscount { get; set; }

        public string ProductSpecification { get; set; }

        public IFormFile ProductImageURL { get; set; }

        public string ProductImage { get; set; }

        public int CategoryEntityId { get; set; }
    }
}
