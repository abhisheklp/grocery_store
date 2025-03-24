using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Backend.Business.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string UserEmail { get; set; }

        public string ProductId { get; set; }

        public string OrderedItems { get; set; }

        public string AmountInItem {get; set;}

        public string OrderedQuantity { get; set; }

        public decimal OrderAmount { get; set; }
    }
}
