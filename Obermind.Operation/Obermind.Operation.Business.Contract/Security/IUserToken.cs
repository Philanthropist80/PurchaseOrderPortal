using System;
using System.Collections.Generic;
using System.Text;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Business.Contract.Security
{
    public interface IUserToken
    {
         string Token { get; set; }
         User User { get; set; }
         DateTime ExpiresAt { get; set; }
    }
}
