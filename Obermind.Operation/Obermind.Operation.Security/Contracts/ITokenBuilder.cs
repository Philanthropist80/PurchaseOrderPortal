using System;
using System.Collections.Generic;
using System.Text;

namespace Obermind.Operation.Security.Contracts
{
    public interface ITokenBuilder
    {
        string Build(string name, string[] roles, DateTime expireDate);
    }
}
