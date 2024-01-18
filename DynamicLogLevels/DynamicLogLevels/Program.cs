using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(path: "config/logSettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var log = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

var app = builder.Build();

Task.Run(async () =>
{
    await Task.Delay(TimeSpan.FromSeconds(2));
    while (true)
    {
        log.Verbose("This is a Verbose log message");
        log.Debug("This is a Debug log message");
        log.Information("This is an Information log message");
        log.Warning("This is a Warning log message");
        log.Error("This is an Error log message");
        log.Fatal("This is a Fatal log message");
        Console.WriteLine();
        await Task.Delay(1000);
    }
});

app.Run();