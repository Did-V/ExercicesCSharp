namespace ExercicesCSharp.Models;
public class LignePanier
{
    public Produit Produit { get; set; }
    public int QuantiteCmd { get; set; }
    public DateTime DateCreationLignePanier { get; private set; }

    public LignePanier(Produit produit, int quantiteCmd = 1)
    {
        if(produit == null)
        {
            throw new ArgumentNullException(nameof(produit),"Création du panier impossible : le produit ne peut pas être à null");
        }
        if(!produit.EstEnStock())
        {
            throw new InvalidOperationException("Impossible de créer une ligne de panier pour un produit en rupture de stock.");
        }
        if(quantiteCmd > produit.Stock)
        {
            throw new InvalidOperationException($"Impossible de créer une ligne de panier pour {quantiteCmd} unités de {produit.Nom}. Stock disponible: {produit.Stock}");
        }
        Produit = produit;
        QuantiteCmd = quantiteCmd;
        Produit.RetirerDuStock(QuantiteCmd);
        DateCreationLignePanier = DateTime.UtcNow;
        Console.WriteLine($"{Produit.Nom} commandé(s).");
    }
    
    public decimal TotalLigne()
    {
        return QuantiteCmd * Produit.Prix;
    }

    public void AfficherDetails()
    {
        Console.WriteLine($"- {QuantiteCmd} x {Produit.Nom} = {TotalLigne():C} créé le {DateCreationLignePanier.ToLocalTime():dd/MM/yyyy HH:mm:ss}");
    }

}