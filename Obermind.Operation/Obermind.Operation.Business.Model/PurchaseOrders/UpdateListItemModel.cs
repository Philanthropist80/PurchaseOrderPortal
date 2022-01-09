using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Obermind.Operation.Business.Model.PurchaseOrders
{
    public class UpdateListItemModel
    {
        [Required]
        public string ItemId { get; set; }

        [Required]
        public string POId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, int.MaxValue)]
        public decimal Amount { get; set; }


        public DateTime UpdatedAt { get; set; }
    }
}
