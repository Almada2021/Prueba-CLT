using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Currency> Currencies => Set<Currency>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de Usuario
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).IsRequired();
            // El email debe ser único [cite: 19]
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.Email).IsRequired();
        });

        // Configuración de Direcciones [cite: 24, 62]
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Street).IsRequired();
            entity.Property(a => a.City).IsRequired();
            entity.Property(a => a.Country).IsRequired();

            // Relación 1:N [cite: 27]
            entity.HasOne(a => a.User)
                  .WithMany(u => u.Addresses)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuración de Monedas [cite: 31-35]
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(c => c.Id);
            // El código de moneda (USD, PYG) debe ser único [cite: 33, 86]
            entity.HasIndex(c => c.Code).IsUnique();
            entity.Property(c => c.Code).IsRequired();
            entity.Property(c => c.RateToBase).HasPrecision(18, 4);
        });
    }
}