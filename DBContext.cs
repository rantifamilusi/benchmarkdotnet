using Microsoft.EntityFrameworkCore;

namespace GenericApi
{
    public class DBContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
    }
}