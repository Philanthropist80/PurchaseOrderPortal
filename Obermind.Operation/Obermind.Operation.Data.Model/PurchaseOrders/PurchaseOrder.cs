using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Data.Model.PurchaseOrders
{
    public class PurchaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string POId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public int OrderBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }


        [ForeignKey("Id")]
        public string UserId { get; set; }
        public virtual User User { get; set; }


    }
}
