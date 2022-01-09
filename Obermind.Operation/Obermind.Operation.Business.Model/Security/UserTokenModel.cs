using System;
using System.Collections.Generic;
using System.Text;

namespace Obermind.Operation.Business.Model.Security
{
    public class UserTokenModel
    {
        public string Token { get; set; }
        public UserModel User { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
