using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasIndex(p => p.DNI)
                .IsUnique();

            modelBuilder.Entity<Teams>()
                .Property(t => t.Diff)
                .HasComputedColumnSql("[GF] - [GC]", stored: true)
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Teams>()
                .Property(t => t.PTS)
                .HasComputedColumnSql("ISNULL([PG], 0) * 3 + ISNULL([PE], 0)", stored: true)
                .ValueGeneratedOnAddOrUpdate();
        }

        

        public DbSet<Teams> Teams { get; set; }
        public DbSet<Player> Player { get; set; }
    }
}