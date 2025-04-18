using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TsaregorodtsevLab2.Data.Entities;

namespace TsaregorodtsevLab2.Data
{
    public class AppConfig
    {
        public string? ConnectionString { get; set; }
    }

    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<MenuPosition> Menu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string confPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\appsettings.json"));
            var conf = new
            {
                ConnectionString = ""
            };

            var data = JsonSerializer.Deserialize<AppConfig>(File.ReadAllText(confPath));

            if (data == null || string.IsNullOrEmpty(data.ConnectionString))
            {
                throw new Exception("Не удалось получить строку подключения");   
            }
            
            optionsBuilder.UseNpgsql(data.ConnectionString);
        }
    }
}
