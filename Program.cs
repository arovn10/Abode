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
                .HasKey(e => e.PersonID); 
            modelBuilder.Entity<Accounts>()
                .HasKey(e => e.email); 
            modelBuilder.Entity<RentalListing>()
                .HasKey(e => e.ListingID);
            modelBuilder.Entity<Account>()
                .HasKey(e => e.AccountID);
            modelBuilder.Entity<AccountType>()
                .HasKey(e => e.AccountTypeID);
            modelBuilder.Entity<Profile>()
                .HasKey(e => e.UserID);
            modelBuilder.Entity<Person>()
                .HasKey(e => e.PersonID);
            modelBuilder.Entity<Tenants>()
                .HasKey(e => e.PersonID);
            modelBuilder.Entity<University>()
                .HasKey(e => e.UniversityID);
            modelBuilder.Entity<UserRole>()
                .HasKey(e => e.UserTypeID);
            modelBuilder.Entity<clients>()
                .HasKey(e => e.AccountTypeID);

        }

        public DbSet<Homes> Homes { get; set; }
        public DbSet<Landlord> Landlord { get; set; }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<RentalListing> RentalListing { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<clients> clients { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}



