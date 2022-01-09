using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.Data.Access.Helpers;
using Obermind.Operation.Data.Access.Mappings.Contracts;
using Obermind.Operation.Data.Model;
using Obermind.Operation.Data.Model.Security;

namespace Obermind.Operation.Data.Access.Mappings.Agreements
{
    public class UserMapping : IMapping
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User()
                {
                    Id = "e8e5d832-765c-45a8-9650-c16f48f84d1b",
                    Username = "tab",
                    FirstName = "Taimoor",
                    LastName = "Adil",
                    Email = "taimurad@hotmail.com",
                    Password = "test1234".WithBCrypt()
                },
                new User()
                {

                    Id = "49aaee27-f4a5-4db5-95b5-8f7b1550a5bd",
                    Username = "TestUser",
                    FirstName = "Obermind",
                    LastName = "Purchase",
                    Email = "test@mail.com",
                    Password = "test1234".WithBCrypt()
                }
            );


            builder.Entity<User>()
                .ToTable("Users")
                .HasKey(x => x.Id);
        }
    }
}
