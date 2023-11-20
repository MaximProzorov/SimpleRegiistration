using Microsoft.EntityFrameworkCore;

namespace SimpleRegistration.Api.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);

        modelBuilder.Entity<Country>()
            .HasKey(c => c.CountryId);

        modelBuilder.Entity<Province>()
            .HasKey(p => p.ProvinceId);

        modelBuilder.Entity<Province>()
            .HasOne(p => p.Country)
            .WithMany(c => c.Provinces)
            .HasForeignKey(p => p.CountryId)
            .IsRequired();

        var countryId1 = Guid.NewGuid();
        var countryId2 = Guid.NewGuid();

        modelBuilder.Entity<Country>().HasData(
            new Country 
            { 
                CountryId = countryId1, 
                Name = "Country 1" 
            },
            new Country 
            {
                CountryId = countryId2,
                Name = "Country 2" 
            }
        );

        modelBuilder.Entity<Province>().HasData(
            new Province 
            {
                ProvinceId = Guid.NewGuid(), 
                Name = "Province 1.1", 
                CountryId = countryId1
            },
            new Province 
            {
                ProvinceId = Guid.NewGuid(), 
                Name = "Province 1.2", 
                CountryId = countryId1
            },
            new Province 
            {
                ProvinceId = Guid.NewGuid(), 
                Name = "Province 2.1", 
                CountryId = countryId2
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
