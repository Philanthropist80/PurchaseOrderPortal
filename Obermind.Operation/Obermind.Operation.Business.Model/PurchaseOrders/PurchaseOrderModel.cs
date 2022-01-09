using System;
using System.Collections.Generic;
using System.Text;

namespace Obermind.Operation.Business.Model.PurchaseOrders
{
    public class PurchaseOrderModel
    {
        public string POId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TotalListItems { get; set; }

        public List<ListItemModel> ListItems { get; set; }
    }
}
