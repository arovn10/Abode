/*using Abode.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Abode.Tables;

namespace Main
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=tcp:myfreedbserverhomerun.database.windows.net,1433;Initial Catalog=myFreeDBserverHR!;Persist Security Info=False;User ID=amaracor;Password=capstone14!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            services.AddDbContext<AbodeDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/error");
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class AbodeDbContext : DbContext
    {
        public AbodeDbContext(DbContextOptions<AbodeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Homes> Homes { get; set; }
        public DbSet<Landlord> Landlord { get; set; }
    }



    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers(); // Add controller services
            builder.Services.AddDbContext<AbodeDbContext>();
            var app = builder.Build();
            app.UseExceptionHandler("/error"); // Optionally handle exceptions
            app.UseStaticFiles(); // Optionally serve static files
            app.UseAuthorization(); // Optionally add authorization
            app.MapControllers(); // Map controllers to endpoints
            app.Run();
        }
    }
}
*/
using Abode.Tables;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Abode.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = "Server=tcp:myfreedbserverhomerun.database.windows.net,1433;Initial Catalog=myFreeDBserverHR!;Persist Security Info=False;User ID=amaracor;Password=capstone14!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            builder.Services.AddControllers();
            builder.Services.AddDbContext<AbodeDbContext>(options => options.UseSqlServer(connectionString));
            
            var app = builder.Build();
            
            app.UseExceptionHandler("/error");
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseRouting();
            app.MapControllers();
            
            app.Run();
        }
    }

    public class AbodeDbContext : DbContext
    {
        public AbodeDbContext(DbContextOptions<AbodeDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homes>()
                .HasKey(e => e.PersonId); // Define PersonId as the primary key
        }

        public DbSet<Homes> Homes { get; set; }
        public DbSet<Landlord> Landlord { get; set; }
    
    }
}

