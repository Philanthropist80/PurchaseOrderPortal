using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.Data.Access.Mappings.Contracts;
using Obermind.Operation.Data.Model;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Data.Access.Mappings.Agreements
{
    public class RoleMapping : IMapping
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role()
                {
                    Id = "1549C3D8-6511-41AA-A82E-8DC75FC7E761",
                    Name = "Admin"
                },
                new Role()
                {
                    Id = "B2A00501-BF6B-4C7F-A789-5986E769F4FB",
                    Name = "User"
                }
            );

            builder.Entity<Role>()
                .ToTable("Roles")
                .HasKey(x => x.Id);

            
        }
    }
}
