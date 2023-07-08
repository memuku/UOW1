using Microsoft.EntityFrameworkCore;
using UOWW.Core.Entities;

namespace UOWW.Infrastructure.Repository
{

    public class PMSDbContext : DbContext
    {
        public PMSDbContext(DbContextOptions<PMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjectRepository> Projects { get; set; }
    }

}
