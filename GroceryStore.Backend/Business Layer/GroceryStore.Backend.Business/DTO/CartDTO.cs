using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }

        public int ProductEntityId { get; set; }

        public int ProductQuantity { get; set; }

        public string UserName { get; set; }
    }
}
