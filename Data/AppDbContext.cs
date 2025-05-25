using EncryptedDataExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EncryptedDataExample.Data;

public class AppDbContext : DbContext
{
    private readonly EncryptionHelper _encryption;

    public AppDbContext(DbContextOptions<AppDbContext> options, EncryptionHelper encryption)
        : base(options) => _encryption = encryption;

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var ssnConverter = new ValueConverter<string, string>(
            v => _encryption.Encrypt(v),
            v => _encryption.Decrypt(v)
        );

        modelBuilder.Entity<User>()
            .Property(u => u.SSN)
            .HasConversion(ssnConverter);
    }
}
