using Comet.Data.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comet.Data.Sqlite
{
    public class CometRSMSqlLiteContext : DbContext
    {
        private string _conn;
        public CometRSMSqlLiteContext(string connectionString) 
        {
            _conn = connectionString;
        } 
        public CometRSMSqlLiteContext(DbContextOptions<CometRSMSqlLiteContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public virtual DbSet<TestDevice> TestDevices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
