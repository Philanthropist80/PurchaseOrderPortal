using System;
using System.Collections.Generic;
using System.Text;
using Obermind.Operation.Business.Contract.Security;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Business.Manager.Security
{
    public class UserToken : IUserToken
    {
        public string Token { get; set; }
        public User User { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
