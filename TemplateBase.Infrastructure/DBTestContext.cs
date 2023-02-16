using System;
using Microsoft.EntityFrameworkCore;
using TemplateBase.Core.Entities;

namespace TemplateBase.Infrastructure
{
    public class DBTestContext: DbContext
    {
        public DBTestContext(DbContextOptions<DBTestContext> options) 
        : base(options)
        {
            
        }

        // Define the table to create
        public DbSet<TestClass> TestClass { get; set; }

        // This method can you use for modify structure the DB as Name, Fields, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestClass>().ToTable("TestTable");
        }
    }
}
