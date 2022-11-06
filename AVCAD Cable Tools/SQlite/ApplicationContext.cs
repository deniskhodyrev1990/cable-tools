using AVCAD.Models;
using Microsoft.EntityFrameworkCore;

namespace AVCAD.SQlite
{
    /// <summary>
    /// EF SQLite context class to get data from the database.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        
        public DbSet<CableType> CableTypes { get; set; }
        public DbSet<CableReel> CableReels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={(Properties.Settings.Default.PathToDatabase == string.Empty ? "cabletools.db" : Properties.Settings.Default.PathToDatabase)}");
        }

    }
}
