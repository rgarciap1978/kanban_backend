using KanbanBoard.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KanbanBoard.DataAccess
{
    public class KanbanBoardDbContext : IdentityDbContext
    {
        public KanbanBoardDbContext(DbContextOptions<KanbanBoardDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Priority>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<KanbanBoardLoginIdentity>(e =>
            {
                e.ToTable(name: "Login");
            });

            modelBuilder.Entity<IdentityRole>(e =>
            {
                e.ToTable(name: "Role");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable(name: "LoginRole");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
