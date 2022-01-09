using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Obermind.Operation.Data.Access.Mappings.Contracts
{
    public interface IMapping
    {
        void Visit(ModelBuilder builder);
    }
}
