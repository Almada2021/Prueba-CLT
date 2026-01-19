using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Currency> Currencies => Set<Currency>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).IsRequired();
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.Email).IsRequired();
            entity.HasData(
                new User { Id = 1, Name = "Tobias Almada", Email = "tobias@example.com", IsActive = true, Password = "hashed_password_1" },
                new User { Id = 2, Name = "Patricio Lopez", Email = "patricio@example.com", IsActive = true, Password = "hashed_password_2" },
                new User { Id = 3, Name = "Juan Perez", Email = "juan@test.com", IsActive = true, Password = "hashed_password_3" },
                new User { Id = 4, Name = "Maria Garcia", Email = "maria@test.com", IsActive = true, Password = "hashed_password_4" },
                new User { Id = 5, Name = "Carlos Lopez", Email = "carlos@test.com", IsActive = true, Password = "hashed_password_5" }
            );
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Street).IsRequired();
            entity.Property(a => a.City).IsRequired();
            entity.Property(a => a.Country).IsRequired();

            entity.HasOne(a => a.User)
                  .WithMany(u => u.Addresses)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(
                new Address { Id = 1, UserId = 1, Street = "Calle Falsa 123", City = "Asunción", Country = "Paraguay", ZipCode = "9999" },
                new Address { Id = 2, UserId = 1, Street = "Palma 456", City = "Asunción", Country = "Paraguay", ZipCode = "1001" },
                new Address { Id = 3, UserId = 2, Street = "Mcal. Estigarribia 789", City = "Santa Rosa", Country = "Paraguay", ZipCode = "6400" },
                new Address { Id = 4, UserId = 3, Street = "Aviadores del Chaco 321", City = "Asunción", Country = "Paraguay", ZipCode = "1205" },
                new Address { Id = 5, UserId = 4, Street = "Cerro Corá 555", City = "Luque", Country = "Paraguay", ZipCode = "2060" }
            );
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => c.Code).IsUnique();
            entity.Property(c => c.Code).IsRequired();
            entity.Property(c => c.RateToBase).HasPrecision(18, 4);
            entity.HasData(
                 new Currency { Id = 1, Code = "PYG", Name = "Guaraní Paraguayo", RateToBase = 1.0m },
                 new Currency { Id = 2, Code = "USD", Name = "Dólar Estadounidense", RateToBase = 7300.0m },
                 new Currency { Id = 3, Code = "BRL", Name = "Real Brasileño", RateToBase = 1350.0m },
                 new Currency { Id = 4, Code = "ARS", Name = "Peso Argentino", RateToBase = 8.5m },
                 new Currency { Id = 5, Code = "EUR", Name = "Euro", RateToBase = 8100.0m }
             );
        });
    }
}