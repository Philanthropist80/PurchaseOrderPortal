using System;
using System.Collections.Generic;
using System.Text;

namespace Obermind.Operation.Data.Access.DAL.Contracts
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
