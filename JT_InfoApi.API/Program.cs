
using JT_InfoApi.Application.Interfaces;
using JT_InfoApi.Domain;
using JT_InfoApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using JT_InfoApi.Domain.Infrastructure;
using JT_InfoApi.Domain.Repositories;
using JT_InfoApi.Appplication.Services;
using JT_InfoApi.API.Middlewares;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using Microsoft.AspNetCore.Diagnostics;

namespace JT_InfoApi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .WriteTo.File(
                            path: @"C:\JT_InfoApi\General\api-log-.txt",
                            rollingInterval: RollingInterval.Day,
                            fileSizeLimitBytes: 10_000_000,
                            rollOnFileSizeLimit: true
                        )
                        .WriteTo.MSSqlServer(
                            connectionString: General.ConnectionBuilder(),
                            sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
                            {
                                TableName = "ErrorLogs",
                                AutoCreateSqlTable = true
                            })
                        .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(General.ConnectionBuilder()));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();
            builder.Services.AddScoped<IHolidayService, HolidayService>();

            var app = builder.Build();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandler != null)
                    {
                        var ex = exceptionHandler.Error;
                        Log.Error(ex, "An unhandled exception occurred while processing {Path}", context.Request.Path);

                        await context.Response.WriteAsJsonAsync(new
                        {
                            status = 500,
                            message = "An unexpected error occurred. Please try again later."
                        });
                    }
                });
            });


            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    dbContext.Database.Migrate();
                    Console.WriteLine("Database migration completed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" DB migration failed: " + ex.Message);
                    throw;
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Web API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddleware<AuditMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
