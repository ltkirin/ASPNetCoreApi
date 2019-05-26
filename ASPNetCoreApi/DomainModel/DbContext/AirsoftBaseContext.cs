using DomainModel.Entity.team;
using DomainModel.Entity.user;
using DomainModel.Entity.weapon;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.DbModel
{
    /// <summary>
    /// Database context for Airsoft base 
    /// </summary>
    public class AirsoftBaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        public AirsoftBaseContext(DbContextOptions options) : base(options)
        {
        }

        public AirsoftBaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=D:\Development\Repo\ASPNetCoreApi\ASPNetCoreApi\DomainModel\Airsoft.mdf;
            Integrated Security=True");
        }

    }
}
