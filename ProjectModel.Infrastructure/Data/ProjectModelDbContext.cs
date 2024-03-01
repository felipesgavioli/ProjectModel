using Microsoft.EntityFrameworkCore;

using ProjectModel.Domain;

namespace ProjectModel.Infrastructure.Data
{
    public class ProjectModelDbContext : DbContext
    {
        public ProjectModelDbContext(DbContextOptions<ProjectModelDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}