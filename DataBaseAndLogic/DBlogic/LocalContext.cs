using DataBaseAndLogic.Logic;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBaseAndLogic.DBlogic
{
    public class LocalContext : DbContext
    {
       
        public DbSet<Lcs> LcsStrings { get; set; }
        
        public static string ConnectionString { get; } = @"Server=DESKTOP-V04VG11\SQLEXPRESS;Database=lcsdb;Trusted_Connection=True;MultipleActiveResultSets=true";


        RandomStringGenerator rsg = new RandomStringGenerator("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");


        public LocalContext(DbContextOptions<LocalContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public LocalContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connecting to DB
                optionsBuilder.UseSqlServer(ConnectionString);
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
