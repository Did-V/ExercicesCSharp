using Microsoft.EntityFrameworkCore;
using ExercicesCSharp.Models;

namespace ExercicesCSharp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Produit> PRODUITS { get; set; }
    public DbSet<Panier> PANIERS { get; set; }
    public DbSet<Client> CLIENTS { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=ExercicesCSharp;Username=postgres;Password=jL6nzitKChLzxm0bNcdU");
    }
}