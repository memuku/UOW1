using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOWW.Core.Interfaces;
using UOWW.Infrastructure.Repository;

namespace UOWW.Infrastructure.UOWW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly PMSDbContext _context;
        private readonly ILogger _logger;

        public IProjectRepository Projects { get; private set; }

        public UnitofWork(
            PMSDbContext context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Projects = new ProjectRepository(_context, _logger);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<int> CompletedAsync()
        {
            throw new NotImplementedException();
        }
    }
}