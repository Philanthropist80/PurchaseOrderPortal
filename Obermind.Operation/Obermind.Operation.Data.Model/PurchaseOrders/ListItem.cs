using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Obermind.Operation.Data.Model.PurchaseOrders
{
    public class ListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ItemId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("PurchaseOrder")]
        public string POId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public bool IsDeleted { get; set; } // For Soft Deletion
    }
}
