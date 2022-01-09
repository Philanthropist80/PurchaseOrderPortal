using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Obermind.Operation.Business.Model.PurchaseOrders
{
    public class UpdatePurchaseOrderDeleteModel
    {
        [Required]
        public string POId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
