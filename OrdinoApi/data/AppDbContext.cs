namespace OrdinoApi.Data;

using OrdinoApi.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{

    private string DbPath { get; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var path = Path.Combine(currentDirectory, "data");
        DbPath = Path.Join(path, "ordino.db");

    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()
            .HasMany(c => c.Visits)
            .WithOne(v => v.Client)
            .HasForeignKey(v => v.ClientId);

        modelBuilder.Entity<Client>()
            .HasOne(c => c.Address)
            .WithOne(a => a.Client)
            .HasForeignKey<Address>(a => a.ClientId);
    }
}
