using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AVCAD.SQlite
{
    public class ApplicationContext : DbContext
    {
        
        public DbSet<Models.CableType> CableTypes { get; set; }
        public DbSet<Models.CableReel> CableReels { get; set; }
        //public DbSet<Models.Unit> Unit { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={(Properties.Settings.Default.PathToDatabase == String.Empty? string.Format("cabletools.db") : Properties.Settings.Default.PathToDatabase)}");
        }

    }
}
