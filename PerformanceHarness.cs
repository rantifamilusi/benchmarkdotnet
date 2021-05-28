using GenericApi.Controllers;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace GenericApi
{
    public class PerformanceHarness
    {
        WeatherForecastController _sut;

        [Params(500, 2000)]
        public int iterationCount;

        [Benchmark]
        public async Task  GetAllWeatherBenchMark()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: "BenchMarkDB")
                .Options;
            var context = new DBContext(options);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger<WeatherForecastController> logger = loggerFactory.CreateLogger<WeatherForecastController>();


            for (int i = 0; i < iterationCount; i++)
            {
                _sut = new WeatherForecastController(context,logger);
                await _sut.GetAllAsync();
            }
        }

    

        [Benchmark]
        public async Task  CreateAsyncBenchMark()
        {
            var options = new DbContextOptionsBuilder<DBContext>()
                .UseInMemoryDatabase(databaseName: "BenchMarkDB")
                .Options;
            var context = new DBContext(options);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger<WeatherForecastController> logger = loggerFactory.CreateLogger<WeatherForecastController>();

            for (int i = 0; i < iterationCount; i++)
            {
                _sut = new WeatherForecastController(context,logger);
                await _sut.CreateAsync(
                new WeatherForecast {
                    Summary = "Posting it out of win",
                    Date = DateTime.Now,
                    TemperatureC = 150,
                    Completed = true,
                });
            }

        }

     
    }
}
