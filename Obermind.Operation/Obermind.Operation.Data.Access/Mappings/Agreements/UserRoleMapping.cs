using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.Data.Access.Mappings.Contracts;
using Obermind.Operation.Data.Model;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Data.Access.Mappings.Agreements
{
    public class UserRoleMapping : IMapping
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    Id = "F48E075B-C74D-478A-8136-A38B09E7CC63",
                    RoleId = "1549C3D8-6511-41AA-A82E-8DC75FC7E761",
                    UserId = "e8e5d832-765c-45a8-9650-c16f48f84d1b"
                },
                new UserRole()
                {

                    Id = "212CF5EF-F517-46D8-9AD5-339CEE387C8A",
                    RoleId = "1549C3D8-6511-41AA-A82E-8DC75FC7E761",
                    UserId = "49aaee27-f4a5-4db5-95b5-8f7b1550a5bd"
                }
            );

            builder.Entity<UserRole>()
                .ToTable("UserRoles")
                .HasKey(x => x.Id);
        }
    }
}
