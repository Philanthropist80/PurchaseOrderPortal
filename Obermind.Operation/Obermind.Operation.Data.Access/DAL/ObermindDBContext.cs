using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Obermind.Operation.Data.Access.Helpers;

namespace Obermind.Operation.Data.Access.DAL
{
    public class ObermindDBContext : DbContext
    {
        public ObermindDBContext(DbContextOptions<ObermindDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mappings = MappingsHelper.GetMainMappings();

            foreach (var mapping in mappings)
            {
                mapping.Visit(modelBuilder);
            }
        }
    }


    //public class ObermindDBContextFactory : IDesignTimeDbContextFactory<ObermindDBContext>
    //{
    //    public ObermindDBContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ObermindDBContext>();
    //        optionsBuilder.UseSqlServer("Data Source =.\\SQLSERVER2017; Initial Catalog = ObermindDB; User Id = remsdba; Password = yell0wtail; ");

    //        return new ObermindDBContext(optionsBuilder.Options);
    //    }
    //}
}
