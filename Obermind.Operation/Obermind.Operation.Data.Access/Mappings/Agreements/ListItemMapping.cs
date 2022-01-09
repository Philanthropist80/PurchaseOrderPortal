using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.Data.Access.Mappings.Contracts;
using Obermind.Operation.Data.Model.PurchaseOrders;

namespace Obermind.Operation.Data.Access.Mappings.Agreements
{
    public class ListItemMapping : IMapping
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<ListItem>().HasData(
                new ListItem() { ItemId = "A71C3887-3C19-4695-8249-7C7F1C6A8DA4", POId = "491E44F7-12DA-4470-95BA-D6B01ACBB45A", Amount = 1000, CreatedAt = DateTime.Now, Name = "D1 - List Item" },
                new ListItem() { ItemId = "E3F1140C-BA46-437F-9234-9CE9D16DA2DF", POId = "491E44F7-12DA-4470-95BA-D6B01ACBB45A", Amount = 200, CreatedAt = DateTime.Now, Name = "D2 - List Item" },
                new ListItem() { ItemId = "2083E168-9B48-4BA9-ABA0-B9252CF6DAD5", POId = "AD8D7916-EE72-4438-9C5E-90B03EC98857", Amount = 200, CreatedAt = DateTime.Now, Name = "D3 - List Item" }
            );

            builder.Entity<ListItem>()
                .ToTable("ListItem")
                .HasKey(x => x.ItemId);
        }
    }
}
