namespace ExercicesCSharp.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public List<LignePanier> LignePaniers { get; set; } = null!;
        public Client Client { get; set; } = null!;
        public DateTime DateCreationPanier { get; private set;}

        private Panier() { } //Constructeur privé pour EF Core   

        public Panier(Client client)
        {
            Client = client;
            DateCreationPanier = DateTime.UtcNow;
            LignePaniers = [];
            Console.WriteLine($"Panier créé et rattaché au client {client.Nom}");
        }

        public void AjouterLignePanier(LignePanier lignePanier)
        {
            if (lignePanier == null)
            {
                throw new ArgumentNullException(nameof(lignePanier), "La ligne du panier ne peut pas être null.");
            }
            
            //Ajouter la commande dans le panier en tant que ligne de commande
            LignePaniers.Add(lignePanier);
            Console.WriteLine($"Ajout de la ligne dans le panier pour le produit {lignePanier.Produit.Nom}");
        }

        public void AfficherProduits()
        {
            if (LignePaniers.Count == 0)
            {
                Console.WriteLine("Le panier est vide.");
            }
            else
            {    
                Console.WriteLine("Produits dans le panier :");
                foreach (var uneLignePanier in LignePaniers)
                {
                    Console.WriteLine($"- {uneLignePanier.QuantiteCmd} x {uneLignePanier.Produit.Nom} : {uneLignePanier.Produit.Prix:C} ({uneLignePanier.Produit.Stock} en stock)");
                }
            }
        }

        //Calculer le total des prix des produits
        public void CalculerTotal()
        {
            decimal total = LignePaniers.Sum(p => p.TotalLigne());
            Console.WriteLine($"Total du panier : {total:C}");
        }
    }
}