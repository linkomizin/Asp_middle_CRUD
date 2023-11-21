
using Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
    

namespace Asp_middle_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IServicesManager, ServiceManager>();

            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

            builder.Services.AddDbContextPool<RepositoryDbContext>(builder =>
            {
                var connectionBuilder =
                    new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
                var connectionString = connectionBuilder.GetConnectionString("Database");
                //  builder.UseNpgsql(connectionString);
                builder.UseSqlite(connectionString);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}