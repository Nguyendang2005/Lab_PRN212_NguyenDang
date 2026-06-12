//using more namespaces for Entity Framwork Core
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Democode_DB
{
    //Declare Category Entity
    public class Category
    {
        public Category() { }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }//End Categories

    public class MyStock : DbContext
    {
        public MyStock() { }

        // These properties map to tables in the database
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStockDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Using Fluent API instead of attributes
            // to limit the length of a Category Name to under 40
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired() // NOT NULL
                .HasMaxLength(40);
        }
    }//end MyStock class
}
