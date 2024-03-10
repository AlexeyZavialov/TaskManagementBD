using System.Xml.Linq;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TaskManagementBD.Models;

using Task = TaskManagementBD.Models.Task;


namespace TaskManagementBD.DAL.Data
{
    public class TMContext : DbContext
    {
        public DbSet<Task> Tasks => Set<Task>();

        public TMContext(DbContextOptions<TMContext> options)
            : base()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TaskManagement");

        //var options = new DbContextOptionsBuilder<TMContext>();




    }
}
