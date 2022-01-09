using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Obermind.Operation.Business.Model.PurchaseOrders
{
    public class UpdatePurchaseOrderStatusModel
    {
        [Required]
        public string POId { get; set; }

        [Required]
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
