using Microsoft.EntityFrameworkCore;
using System;

namespace LCS_csharp_
{
    class LocalContext : DbContext
    {
        public DbSet<Lcs> LcsStrings { get; set; }
        
        RandomStringGenerator rsg = new RandomStringGenerator("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");


        public LocalContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connecting to DB
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-K3B9EQ2\SQLEXPRESS;Database=lcsdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //settind Standart model data
            modelBuilder.Entity<Lcs>().HasData(
            new Lcs[] {
            new Lcs(rsg.getRandString(), rsg.getRandString()){ Id = 1 },// setting ids by ourselves to avoid errors 
            new Lcs(rsg.getRandString(), rsg.getRandString()){ Id = 2 },
            new Lcs(rsg.getRandString(), rsg.getRandString()){ Id = 3 }
             });

        }
    }
}
