namespace ExercicesCSharp.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public List<Produit> Produits { get; set; } = null!;
        public Client Client { get; set; } = null!;
        public int Quantite { get; set; }
        public DateTime DateCreationPanier { get; private set;}

        private Panier() { } //Constructeur privé pour EF Core   

        public Panier(Client client)
        {
            Client = client;
            DateCreationPanier = DateTime.UtcNow;
            Produits = [];
            Console.WriteLine($"Panier créé et rattaché au client {client.Nom}");
        }

        public void AjouterProduit(Produit produit, int quantite = 1)
        {
            if (produit == null)
            {
                throw new ArgumentNullException(nameof(produit), "Le produit ne peut pas être null.");
            }
            if (quantite <= 0)
            {
                throw new ArgumentException("Impossible de créer une commande avec une quantité nulle ou négative.");
            }
            if(!produit.EstEnStock())
            {
                throw new InvalidOperationException("Impossible de créer une commande pour un produit en rupture de stock.");
                //Remarque : InvalidOperationException est utilisée ici pour indiquer que l'état actuel de l'objet (produit en rupture de stock) ne permet pas l'opération demandée (création d'une commande).
                //Différence entre ArgumentException et InvalidOperationException : ArgumentException est utilisée lorsque l'argument fourni à une méthode n'est pas valide, tandis qu'InvalidOperationException est utilisée lorsque l'état actuel de l'objet ne permet pas l'opération demandée. Dans ce cas, le produit est en rupture de stock, ce qui rend impossible la création d'une commande.
            }
            if(quantite > produit.Stock)
            {
                throw new InvalidOperationException($"Impossible de créer une commande pour {quantite} unités de {produit.Nom}. Stock disponible: {produit.Stock}");
            }
            //Si le produit est en stock alors...
            if (produit.EstEnStock())
            {    
                //Ajouter le produit au panier
                Produits.Add(produit);
                //Retirer la quantité spécifiée du stock du produit
                produit.RetirerDuStock(quantite); 
                Console.WriteLine($"Produit ajouté au panier : {produit.Nom}, Prix: {produit.Prix:C}, Stock disponible: {produit.Stock}");
            }
            else
            {
                Console.WriteLine($"Le produit {produit.Nom} est en rupture de stock et ne peut pas être ajouté au panier.");
            }
        }

        public void AfficherProduits()
        {
            if (Produits.Count == 0)
            {
                Console.WriteLine("Le panier est vide.");
            }
            else
            {    
                Console.WriteLine("Produits dans le panier :");
                foreach (var produit in Produits)
                {
                    Console.WriteLine($"- {produit.Nom} : {produit.Prix:C} ({produit.Stock} en stock)");
                }
            }
        }

        //Calculer le total des prix des produits
        public void CalculerTotal()
        {
            decimal total = Produits.Sum(p => p.Prix);
            Console.WriteLine($"Total du panier : {total:C}");
        }
    }
}