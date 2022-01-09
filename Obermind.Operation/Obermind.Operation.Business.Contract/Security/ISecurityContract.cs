using System;
using System.Collections.Generic;
using System.Text;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Business.Contract.Security
{
    public interface ISecurityContract
    {
        User GetUser(string userName);
        bool IsAdminUser(string userName);
    }
}
