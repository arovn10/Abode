using Abode.Tables;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            modelBuilder.Entity<Accounts>()
                .HasKey(e => e.email); // Define PersonId as the primary key
        }

        public DbSet<Homes> Homes { get; set; }
        public DbSet<Landlord> Landlord { get; set; }

        public DbSet<Accounts> Accounts { get; set; }
    }
}



