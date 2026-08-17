using Microsoft.EntityFrameworkCore;
using ExercicesCSharp.Models;

namespace ExercicesCSharp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Produit> Produits { get; set; }
    public DbSet<Commande> Commandes { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=ExercicesCSharp;Username=postgres;Password=jL6nzitKChLzxm0bNcdU");
    }
}