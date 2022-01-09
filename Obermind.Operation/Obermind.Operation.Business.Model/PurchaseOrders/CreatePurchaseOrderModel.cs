using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Obermind.Operation.Business.Model.PurchaseOrders
{
    public class CreatePurchaseOrderModel
    {
        
        public string POId { get; set; }

        [Required]
        public string Name { get; set; }

        //[Range(0.01, int.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ListItemModel> ListItems { get; set; }
    }
}
