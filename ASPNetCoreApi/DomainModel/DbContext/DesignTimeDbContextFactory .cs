using DomainModel.DbModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DomainModel.DbContext
{
    /// <summary>
    /// Airsoft base Context factory
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AirsoftBaseContext>
    {
        public AirsoftBaseContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AirsoftBaseContext> optionsBuilder = new DbContextOptionsBuilder<AirsoftBaseContext>();

            return new AirsoftBaseContext(optionsBuilder.Options);
        }
    }
}
