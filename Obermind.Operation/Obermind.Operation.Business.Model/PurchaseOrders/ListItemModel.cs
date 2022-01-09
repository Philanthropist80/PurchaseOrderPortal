using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Obermind.Operation.Business.Model.PurchaseOrders
{
    public class ListItemModel
    {
        public string ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, int.MaxValue)]
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string POId { get; set; }
        public string POName { get; set; }
        
    }
}
