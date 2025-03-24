using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Backend.Presentation.Models
{
    public class CartModel
    {
        public int CartId { get; set; }

        public int ProductEntityId { get; set; }

        public int ProductQuantity { get; set; }

        public string UserName { get; set; }
    }
}
