using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Obermind.Operation.Business.Model.Security
{
    public class ChangeUserPasswordModel
    {
        [Required]
        public string Password { get; set; }

    }
}
