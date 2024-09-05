using Abode.Tables;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YourNamespace;

namespace Abode.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    public class AbodeDbContextOld : DbContext
    {
        public AbodeDbContextOld(DbContextOptions<AbodeDbContextOld> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homes>()
                .HasKey(e => e.PersonID); 
            modelBuilder.Entity<Accounts>()
                .HasKey(e => e.userId); 
            modelBuilder.Entity<RentalListings>()
                .HasKey(e => e.ListingID);
            modelBuilder.Entity<AccountType>()
                .HasKey(e => e.AccountTypeID);
            modelBuilder.Entity<Profile>()
                .HasKey(e => e.UserID);
            modelBuilder.Entity<Person>()
                .HasKey(e => e.PersonID);
            modelBuilder.Entity<Tenants>()
                .HasKey(e => e.PersonID);
            modelBuilder.Entity<AddProperties>()
                .HasKey(e => e.property_id);
            modelBuilder.Entity<University>()
                .HasKey(e => e.UniversityID);
            modelBuilder.Entity<UserRole>()
                .HasKey(e => e.UserTypeID);
            modelBuilder.Entity<clients>()
                .HasKey(e => e.AccountTypeID);
            modelBuilder.Entity<Messages>()
                .HasKey(e => e.MessageID);
            modelBuilder.Entity<amenities>().HasNoKey();
        }

        public DbSet<Homes> Homes { get; set; }
        public DbSet<Landlord> Landlord { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AddProperties> AddProperties { get; set; }
        public DbSet<RentalListings> RentalListing { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<clients> clients { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<amenities> amenities { get; set; }
    }
}
