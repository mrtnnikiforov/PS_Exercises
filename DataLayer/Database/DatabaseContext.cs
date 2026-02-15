using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Others;

namespace DataLayer.Database
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<LogEntry> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            
            var user =  new DatabaseUser
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10)
            };

            var user2 = new DatabaseUser
            {
                Id = 2,
                Name = "Ivan Atanasov",
                Password = "12345",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(5)
            };

            var user3 = new DatabaseUser
            {
                Id = 3,
                Name = "Kostadin Harizanov",
                Password = "123456",
                Role = UserRolesEnum.INSPECTOR,
                Expires = DateTime.Now.AddYears(20)
            };
            modelBuilder.Entity<DatabaseUser>().HasData(user, user2, user3);
        }

        public DbSet<DatabaseUser> Users { get; set; }
    }
}
