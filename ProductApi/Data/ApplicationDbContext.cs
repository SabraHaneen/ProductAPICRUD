
using Microsoft.EntityFrameworkCore;
using ProductApi.Controllers;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        // crate constructor to allow dependancies injection of my appDb context and this constructor will be empty and will have obj inhert from base and i will pass the obj options to inhert class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }
        //then i can migrate and updatebase
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create obj from Products table with data
            //seeding (populating a database with initial data)
            modelBuilder.Entity<Products>().HasData(
                new Products { Id=1,Name="LapTop",Description="aaa"},
                new Products { Id = 2, Name = "Desktop", Description = "aaa" }

                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Products> Product { get; set; }
    }
}
