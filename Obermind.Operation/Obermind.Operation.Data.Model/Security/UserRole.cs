using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Obermind.Operation.Data.Model.Security
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [ForeignKey("Id")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Id")]
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
