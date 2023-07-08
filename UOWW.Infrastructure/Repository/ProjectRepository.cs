using Microsoft.Extensions.Logging;
using UOWW.Core.Entities;
using UOWW.Core.Interfaces;

namespace UOWW.Infrastructure.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(PMSDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
