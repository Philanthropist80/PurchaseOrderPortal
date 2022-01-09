using Obermind.Operation.Data.Model;
using System;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Security.Contracts
{
    public interface ISecurityContext
    {
        User User { get; }

        bool IsAdministrator { get; }
    }
}
