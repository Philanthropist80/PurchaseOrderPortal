using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Obermind.Operation.Data.Access.Mappings.Contracts;
using Obermind.Operation.Data.Model;
using Obermind.Operation.Data.Model.PurchaseOrders;

namespace Obermind.Operation.Data.Access.Mappings.Agreements
{
 
    public class PurchaseOrderMapping : IMapping
    {
        public void Visit(ModelBuilder builder)
        {
            builder.Entity<PurchaseOrder>().HasData(
                new PurchaseOrder()
                {
                    POId = "491E44F7-12DA-4470-95BA-D6B01ACBB45A",
                    Name = "D1 - Purchase Order",
                    Status = "SUBMIT",
                    CreatedAt = DateTime.Now,
                    OrderBy = 1,
                    Amount = 1200,
                    UserId = "e8e5d832-765c-45a8-9650-c16f48f84d1b",
                    //ListItems = new List<ListItem>()
                    //{
                    //    new ListItem() { ItemId = "1", POId = "1", Amount = 1000, CreatedAt = DateTime.Now, Name = "D1 - List Item"},
                    //    new ListItem() { ItemId = "2", POId = "1", Amount = 200, CreatedAt = DateTime.Now, Name = "D2 - List Item"}
                    //}
                },
                new PurchaseOrder()
                {
                    POId = "AD8D7916-EE72-4438-9C5E-90B03EC98857",
                    Name = "D2 - Purchase Order",
                    Status = "DRAFT",
                    CreatedAt = DateTime.Now,
                    OrderBy = 2,
                    Amount = 200,
                    UserId = "e8e5d832-765c-45a8-9650-c16f48f84d1b",
                    //ListItems = new List<ListItem>()
                    //{
                    //    new ListItem() { ItemId = "3", POId = "2", Amount = 200, CreatedAt = DateTime.Now, Name = "D3 - List Item" }
                    //}
                }
            );


            builder.Entity<PurchaseOrder>()
                .ToTable("PurchaseOrder")
                .HasKey(x => x.POId);
        }
    }
}
