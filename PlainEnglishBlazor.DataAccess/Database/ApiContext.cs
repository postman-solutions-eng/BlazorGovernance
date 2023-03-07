using Microsoft.EntityFrameworkCore;
using PlainEnglishBlazor.Shared.Models;

namespace PlainEnglishBlazor.DataAccess.Database
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "WeatherDb");
        }

        public DbSet<WeatherForecast> Weather { get; set; }
    }
}
