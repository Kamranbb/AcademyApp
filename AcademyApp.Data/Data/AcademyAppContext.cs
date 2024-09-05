using AcademyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AcademyApp.Data.Data
{
    public class AcademyAppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public AcademyAppContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
