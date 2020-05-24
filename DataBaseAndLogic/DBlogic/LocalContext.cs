using DataBaseAndLogic.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DataBaseAndLogic.DBlogic
{
    public class LocalContext : DbContext
    {
       
        public DbSet<Lcs> LcsStrings { get; set; }
        
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
            optionsBuilder.UseSqlServer(GetConfigurationString("appsettings.json", "DefaultConnection"));
        }

        public static string GetConfigurationString(string filename, string connectionstringname)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(@filename)
            .Build();
            return configuration.GetConnectionString(connectionstringname);
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
