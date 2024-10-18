using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Abode.Models;

public partial class AbodeDbContext : DbContext
{
    public AbodeDbContext()
    {
    }

    public AbodeDbContext(DbContextOptions<AbodeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<AddProperty> AddProperties { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Financial> Financials { get; set; }

    public virtual DbSet<Home> Homes { get; set; }

    public virtual DbSet<Landlord> Landlords { get; set; }

    public virtual DbSet<LeaseAgreement> LeaseAgreements { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<OldProfile> OldProfiles { get; set; }

    public virtual DbSet<OldTenant> OldTenants { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<PropertiesDelete> PropertiesDeletes { get; set; }

    public virtual DbSet<RentalListing> RentalListings { get; set; }

    public virtual DbSet<ShowingScheduler> ShowingSchedulers { get; set; }

    public virtual DbSet<Spec> Specs { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<TenantsOld> TenantsOlds { get; set; }

    public virtual DbSet<University> Universities { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Utility> Utilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=tcp:abodeserver.database.windows.net,1433;Initial Catalog=Abode;User ID=amaracor;Password=capstone14!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Accounts__CB9A1CFF0009EF1E");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePic)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profilePic");
            entity.Property(e => e.School)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("school");
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userType");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasKey(e => e.AccountTypeId).HasName("PK__AccountT__8F95854F5035A25B");

            entity.ToTable("AccountType");

            entity.Property(e => e.AccountTypeId)
                .ValueGeneratedNever()
                .HasColumnName("AccountTypeID");
            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("userType");
        });

        modelBuilder.Entity<AddProperty>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__AddPrope__735BA4636B75A7CA");

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Amenities)
                .HasColumnType("text")
                .HasColumnName("amenities");
            entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");
            entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LeaseTerms)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("leaseTerms");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Photo)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.School)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("school");
            entity.Property(e => e.SquareFeet).HasColumnName("squareFeet");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.AmenityId).HasName("PK__amenitie__842AF50B8012BDD1");

            entity.ToTable("amenities");

            entity.Property(e => e.Backyard).HasColumnName("backyard");
            entity.Property(e => e.CentralAc).HasColumnName("centralAC");
            entity.Property(e => e.Driveway).HasColumnName("driveway");
            entity.Property(e => e.Fireplace).HasColumnName("fireplace");
            entity.Property(e => e.FullyFurnished).HasColumnName("fullyFurnished");
            entity.Property(e => e.LaundryUnit).HasColumnName("laundryUnit");
            entity.Property(e => e.PetFriendly).HasColumnName("petFriendly");
            entity.Property(e => e.Pool).HasColumnName("pool");
            entity.Property(e => e.PowderRoom).HasColumnName("powderRoom");
            entity.Property(e => e.PropertyId).HasColumnName("propertyID");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.AccountTypeId).HasName("PK__clients__8F95854FEAA43090");

            entity.ToTable("clients");

            entity.Property(e => e.AccountTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountTypeID");
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userType");
        });

        modelBuilder.Entity<Financial>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Financia__735BA4630B0A7F49");

            entity.Property(e => e.PropertyId)
                .ValueGeneratedNever()
                .HasColumnName("property_id");
            entity.Property(e => e.Insurances)
                .HasColumnType("text")
                .HasColumnName("insurances");
            entity.Property(e => e.Loans)
                .HasColumnType("text")
                .HasColumnName("loans");
            entity.Property(e => e.Purchase)
                .HasColumnType("text")
                .HasColumnName("purchase");

            entity.HasOne(d => d.Property).WithOne(p => p.Financial)
                .HasForeignKey<Financial>(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Financial__prope__236943A5");
        });

        modelBuilder.Entity<Home>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Homes__AA2FFB85C7735ED8");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Landlord>(entity =>
        {
            entity.HasKey(e => e.LandlordId).HasName("PK__Landlord__8EC792434DB6FD8A");

            entity.ToTable("Landlord");

            entity.Property(e => e.LandlordId)
                .ValueGeneratedNever()
                .HasColumnName("LandlordID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LeaseAgreement>(entity =>
        {
            entity.HasKey(e => e.LeaseId).HasName("PK__LeaseAgr__017619F0A494D9EB");

            entity.Property(e => e.LeaseId)
                .ValueGeneratedNever()
                .HasColumnName("lease_id");
            entity.Property(e => e.Deposit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deposit");
            entity.Property(e => e.LeaseEndDate).HasColumnName("leaseEndDate");
            entity.Property(e => e.LeaseStartDate).HasColumnName("leaseStartDate");
            entity.Property(e => e.LeaseTerms)
                .HasColumnType("text")
                .HasColumnName("leaseTerms");
            entity.Property(e => e.MonthlyRent)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monthlyRent");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");

            entity.HasOne(d => d.Property).WithMany(p => p.LeaseAgreements)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__LeaseAgre__prope__1DB06A4F");

            entity.HasOne(d => d.Tenant).WithMany(p => p.LeaseAgreements)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK__LeaseAgre__tenan__1CBC4616");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C037C970B0C0F");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("dateTime");
            entity.Property(e => e.Messages)
                .HasColumnType("text")
                .HasColumnName("messages");
            entity.Property(e => e.PropertyId).HasColumnName("propertyID");
            entity.Property(e => e.Sendee)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sendee");
            entity.Property(e => e.Sender)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sender");
        });

        modelBuilder.Entity<OldProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Profile__1788CCAC6B92214D");

            entity.ToTable("OldProfile");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.AuthToken)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoginName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NamePreferred)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePic)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Pronouns)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserTypeID");
        });

        modelBuilder.Entity<OldTenant>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Tenants__AA2FFB85199FFF83");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFB851FF53AB6");

            entity.ToTable("Person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__Photos_N__21B7B5E2D1754B36");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhotoLink)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Profile__735BA463B31D3DC3");

            entity.ToTable("Profile");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AirConditioning)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("air_conditioning");
            entity.Property(e => e.Amenities)
                .HasColumnType("text")
                .HasColumnName("amenities");
            entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");
            entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");
            entity.Property(e => e.Bio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bio");
            entity.Property(e => e.Deposit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deposit");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Laundry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("laundry");
            entity.Property(e => e.LeaseTerms)
                .HasColumnType("text")
                .HasColumnName("leaseTerms");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Parking)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("parking");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PublicEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("publicEmail");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<PropertiesDelete>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Properti__735BA4636B0AB0A7");

            entity.ToTable("PropertiesDELETE");

            entity.Property(e => e.PropertyId)
                .ValueGeneratedNever()
                .HasColumnName("property_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AirConditioning)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("air_conditioning");
            entity.Property(e => e.Amenities)
                .HasColumnType("text")
                .HasColumnName("amenities");
            entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");
            entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");
            entity.Property(e => e.Deposit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("deposit");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Door)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("door");
            entity.Property(e => e.Flooring)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("flooring");
            entity.Property(e => e.Insurances)
                .HasColumnType("text")
                .HasColumnName("insurances");
            entity.Property(e => e.Keys)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("keys");
            entity.Property(e => e.Laundry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("laundry");
            entity.Property(e => e.LeaseTerms)
                .HasColumnType("text")
                .HasColumnName("leaseTerms");
            entity.Property(e => e.Loans)
                .HasColumnType("text")
                .HasColumnName("loans");
            entity.Property(e => e.MaintenanceRequestsAssignee)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("maintenance_requests_assignee");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Paint)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paint");
            entity.Property(e => e.Parking)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("parking");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Purchase)
                .HasColumnType("text")
                .HasColumnName("purchase");
            entity.Property(e => e.Responsibility)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("responsibility");
            entity.Property(e => e.School)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("school");
            entity.Property(e => e.SquareFeet).HasColumnName("squareFeet");
            entity.Property(e => e.UtilityProviders)
                .HasColumnType("text")
                .HasColumnName("utility_providers");
        });

        modelBuilder.Entity<RentalListing>(entity =>
        {
            entity.HasKey(e => e.ListingId).HasName("PK__RentalLi__BF3EBEF068ABE8EB");

            entity.ToTable("RentalListing");

            entity.Property(e => e.ListingId)
                .ValueGeneratedNever()
                .HasColumnName("ListingID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyRent).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PropertyName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShowingScheduler>(entity =>
        {
            entity.HasKey(e => e.ShowingId).HasName("PK__ShowingS__3213D2C770A5C7DB");

            entity.ToTable("ShowingScheduler");

            entity.Property(e => e.ShowingId)
                .ValueGeneratedNever()
                .HasColumnName("showingId");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.PropertyId).HasColumnName("propertyId");
            entity.Property(e => e.PublicShowing).HasColumnName("publicShowing");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");

            entity.HasMany(d => d.Users).WithMany(p => p.Showings)
                .UsingEntity<Dictionary<string, object>>(
                    "ShowingAttendee",
                    r => r.HasOne<Account>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ShowingAt__userI__0C50D423"),
                    l => l.HasOne<ShowingScheduler>().WithMany()
                        .HasForeignKey("ShowingId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ShowingAt__showi__0B5CAFEA"),
                    j =>
                    {
                        j.HasKey("ShowingId", "UserId").HasName("PK__ShowingA__DEAA7308A250B697");
                        j.ToTable("ShowingAttendees");
                        j.IndexerProperty<int>("ShowingId").HasColumnName("showingId");
                        j.IndexerProperty<int>("UserId").HasColumnName("userId");
                    });
        });

        modelBuilder.Entity<Spec>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Specs__735BA463BA02E669");

            entity.Property(e => e.PropertyId)
                .ValueGeneratedNever()
                .HasColumnName("property_id");
            entity.Property(e => e.Door)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("door");
            entity.Property(e => e.Flooring)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("flooring");
            entity.Property(e => e.Keys)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("keys");
            entity.Property(e => e.Paint)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paint");
            entity.Property(e => e.SquareFeet).HasColumnName("squareFeet");

            entity.HasOne(d => d.Property).WithOne(p => p.Spec)
                .HasForeignKey<Spec>(d => d.PropertyId)
                .HasConstraintName("FK_Specs_AddProperties");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK__Tenants___D6F29F3E44BF94A5");

            entity.ToTable("Tenant");

            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LeaseEndDate).HasColumnName("leaseEndDate");
            entity.Property(e => e.LeaseStartDate).HasColumnName("leaseStartDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<TenantsOld>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK__Tenants__D6F29F3E7F6564E0");

            entity.ToTable("TenantsOld");

            entity.Property(e => e.TenantId)
                .ValueGeneratedNever()
                .HasColumnName("tenant_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LeaseEndDate).HasColumnName("leaseEndDate");
            entity.Property(e => e.LeaseStartDate).HasColumnName("leaseStartDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Property).WithMany(p => p.TenantsOlds)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__Tenants__propert__18EBB532");
        });

        modelBuilder.Entity<University>(entity =>
        {
            entity.HasKey(e => e.UniversityId).HasName("PK__Universi__9F19E19CCB1D800A");

            entity.ToTable("University");

            entity.Property(e => e.UniversityId)
                .ValueGeneratedNever()
                .HasColumnName("UniversityID");
            entity.Property(e => e.School)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("school");
            entity.Property(e => e.UniversityLocation)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PK__UserRole__40D2D8F684B41C9C");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserTypeId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserTypeID");
            entity.Property(e => e.UserRoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Utility>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Utilitie__735BA463C7569AD1");

            entity.Property(e => e.PropertyId)
                .ValueGeneratedNever()
                .HasColumnName("property_id");
            entity.Property(e => e.MaintenanceRequestsAssignee)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("maintenance_requests_assignee");
            entity.Property(e => e.Responsibility)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("responsibility");
            entity.Property(e => e.UtilityProviders)
                .HasColumnType("text")
                .HasColumnName("utility_providers");

            entity.HasOne(d => d.Property).WithOne(p => p.Utility)
                .HasForeignKey<Utility>(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Utilities__prope__2645B050");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
