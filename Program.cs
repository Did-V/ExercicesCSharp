using ExercicesCSharp.Models;
using ExercicesCSharp.Data;
using Microsoft.EntityFrameworkCore;

//Exercice 1 : Variables et affichage
string nom = "Jean";
int age = 30;
double taille = 1.80;

Console.WriteLine("\nExercice 1 : Variables et affichage");
Console.WriteLine($"{nom} a {age} ans et mesure {taille} m.");

//Exercice 2 : Conditions
Console.WriteLine("\nExercice 2 : Conditions");
if (age >= 18)
{
    if (age >= 65)
    {    
        Console.WriteLine($"{nom} est senior.");
    }
    else
    {
        Console.WriteLine($"{nom} est majeur.");
    }
}
else
{
    Console.WriteLine($"{nom} est mineur.");
}

//Exercice 3 : Boucles
Console.WriteLine("\nExercice 3 : Boucles");
for (int nNombre = 1; nNombre <= 10; nNombre++)
{
    Console.WriteLine($"{nNombre} x 7 = {nNombre * 7}");
}

//Exercice 4 : Listes et LINQ
Console.WriteLine("\nExercice 4 : Listes et LINQ");
List<int> nombres = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
var Somme = nombres.Sum();
Console.WriteLine("Somme des nombres : " + Somme);
var Moyenne = nombres.Average();
Console.WriteLine("Moyenne des nombres : " + Moyenne);
var maxNombre = nombres.Max();
Console.WriteLine("Nombre maximum : " + maxNombre);
var minNombre = nombres.Min();
Console.WriteLine("Nombre minimum : " + minNombre);
var nombresPairs = nombres.Where(n => n % 2 == 0).ToList();
Console.WriteLine("Nombres pairs : " + string.Join(", ", nombresPairs));

//Exercice 5 : Une classe simple avec validation
Console.WriteLine("\nExercice 5 : Une classe simple avec validation");
try
{
    Client client = new("Jean", "jean@example.com");
    Console.WriteLine($"Client créé : {client.Nom}, {client.Email}, {client.DateInscription.ToLocalTime()}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erreur lors de la création du client : {ex.Message}");
}
//Client sans e-mail :  pas d'erreur
try
{
    Client clientSansEmail = new("Jean", "");
    Console.WriteLine($"Client créé : {clientSansEmail.Nom}, {clientSansEmail.Email}, {clientSansEmail.DateInscription.ToLocalTime()}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erreur lors de la création du client : {ex.Message}");
}
//Client avec e-mail sans @ : erreur
try
{
    Client clientAvecEmailInvalide = new("Laura", "lauraexemple.com");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erreur lors de la création du client : {ex.Message}");
}

//Exercice 6 : Méthodes et comportements
Console.WriteLine("\nExercice 6 : Méthodes et comportements");
try
{
    Client NouveauClient = new("Marie", "marie@exemple.com");
    Console.WriteLine($"Client créé : {NouveauClient.Nom}, {NouveauClient.Email}, {NouveauClient.DateInscription.ToLocalTime()}");
    // Vérifier si le client est nouveau
    if (Client.EstNouveauClient(NouveauClient.DateInscription))
    {
        Console.WriteLine($"{NouveauClient.Nom} est un nouveau client.");
    }
    else
    {
        Console.WriteLine($"{NouveauClient.Nom} est un ancien client.");
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erreur lors de la création du client : {ex.Message}");
}

//Exercice 7 : Gestion d'erreurs
Console.WriteLine("\nExercice 7 : Gestion d'erreurs");
try
{
    int resultat1 = Client.DiviserNombre(10, 4);
    Console.WriteLine($"Résultat de la division : {resultat1}");
    int resultat2 = Client.DiviserNombre(10, 0);
    Console.WriteLine($"Résultat de la division : {resultat2}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Erreur lors de la division : {ex.Message}");
}

//Exercice 8 : Classes en relation
Console.WriteLine("\nExercice 8 : Classes en relation");
Produit produit1 = new("Ordinateur", 1200.00m, 5);
Produit produit2 = new("Souris", 25.00m, 10);
Produit produit3 = new("Clavier", 45.00m, 0); //Produit en rupture de stock
Client clientCmd = new("Rachelle","rachelle@exemple.com");
try{    
    LignePanier ligneDuPanier_Produit1 = new(produit1);
    LignePanier ligneDuPanier_Produit2 = new(produit2,5);
    Panier monPanier = new(clientCmd);
    monPanier.AjouterLignePanier(ligneDuPanier_Produit1);
    ligneDuPanier_Produit1.AfficherDetails();
    monPanier.AjouterLignePanier(ligneDuPanier_Produit2);
    try
    {    
        LignePanier ligneDuPanier_Produit3 = new(produit3);
        monPanier.AjouterLignePanier(ligneDuPanier_Produit3);
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Impossible de créer la ligne du panier avec {nameof(produit3)} : {ex.Message}");
    }
    monPanier.AfficherProduits();
    monPanier.CalculerTotal();
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Création du panier impossible : {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Création du panier impossible : {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Création du panier impossible : {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Création du panier impossible : {ex.Message}");
}

//Exercice 9 : Combinaison complète
Console.WriteLine("\nExercice 9 : Combinaison complète");
//Créer 3 avis sur chaque produit
Avis avis1Produit1 = new(produit1, 5, "Excellent PC. Très Puissant.");
Avis avis2Produit1 = new(produit1, 3, "Problème avec le livreur. PC fonctionnel mais rayé sur le capot.");
Avis avis3Produit1 = new(produit1, 1, "Nul : J'ai eu du mal à installer Windows.");
Avis avis1Produit2 = new(produit2, 4, "La souris est bien dans l'ensemble.");
Avis avis2Produit2 = new(produit2, 5, "Parfait. Exactement ce qu'il me fallait avec cette souris.");
Avis avis3Produit2 = new(produit2, 3, "La souris fonctionne mais j'ai des déconnexions de temps de temps.");
Avis avis1Produit3 = new(produit3, 2, "Certaines touches ne fonctionne pas sur ce clavier");
Avis avis2Produit3 = new(produit3, 1, "On m'a livré un clavier qui ne contient que les lettres A-Z-E-R-T-Y... Et pourtant c'est un clavier QWERTY. Mais c'est une blague ???");
Avis avis3Produit3 = new(produit3, 1, "On m'a livré un clavier QWERTY. J'ai pourtant demandé un BEPO.");
List<Avis> ListeAvis = [avis1Produit1,avis2Produit1,avis3Produit1,avis1Produit2,avis2Produit2,avis3Produit2,avis1Produit3,avis2Produit3,avis3Produit3];
var NotesMoyennes = ListeAvis
    .GroupBy(avis => new{avis.Produit.Id,avis.Produit.Nom}) //Remarque : Ne pas utiliser directement avis.Produit car C# risque de créer un groupe différent pour chaque avis afin de faire les comparaisons par adresses
    //Remarque 2 : Utiliser l'objet avis.Produit ici regroupe tous l'objet Produit. On n'a besoin de regrouper que l'identifiant. Il faut ajouter aussi le nom afin que groupe puisse le récupérer.
    .Select(groupe => new
    {
        NomProduit = groupe.Key.Nom,    //Remarque :  groupe.Key est un objet "Produit", donc on peut faire .Nom
        NoteMoyenne = Math.Round(groupe.Average(avis => avis.Note), 2)
    });
Console.WriteLine("Note moyenne des produits : ");
foreach(var LaNote in NotesMoyennes)
{
    Console.WriteLine($"- {LaNote.NomProduit} => {LaNote.NoteMoyenne}");
}

//Exercice 10 : Persistance en base
Console.WriteLine("\nExercice 10 : Persistance en base");
Client client1 = null!; //1er client
Client client2 = null!; //2e client
Produit produitMachette = null!;    //Un produit appelé machette
Produit produitGriffe = null!;    //Un produit appelé griffe

using var context = new AppDbContext(); //Création d'une instance du contexte de base de données pour interagir avec la base de données PostgreSQL
//Créer 2 clients dans la base
try
{
    client1 = new("Jason","jasonvorhees@zombie.com");
    client2 = new("Freddy","freddykrueger@vaudou.com");
    if (!context.Clients.Any())
    {    
        context.Clients.Add(client1);
        context.Clients.Add(client2);
        context.SaveChanges();
        Console.WriteLine("Clients créés en base");
    }
}
catch(ArgumentException ex)
{
    Console.WriteLine($"Impossible de créer les clients : {ex.Message}");
    return;
}
catch(Exception ex)
{
    Console.WriteLine($"Impossible de créer les clients : {ex.Message}");
    return;
}
//Créer 2 produits
try
{    
    produitMachette = new("Machette", 50.00m, 10);
    produitGriffe = new("Griffe", 100.00m, 20);
    if (!context.Produits.Any())
    {    
        context.Produits.Add(produitMachette);
        context.Produits.Add(produitGriffe);
        context.SaveChanges();
    }
}
catch(ArgumentException ex)
{
    Console.WriteLine($"Impossible de créer les produits : {ex.Message}");
    return;
}
catch(Exception ex)
{
    Console.WriteLine($"Impossible de créer les produits : {ex.Message}");
    return;
}
//Créer une commande pour le 2e client
Commande CmdClient2 = new(client2,produitGriffe,3);
try
{ 
    if (!context.Commandes.Any())
    {    
        context.Commandes.Add(CmdClient2);
        context.SaveChanges();
        Console.WriteLine($"Commande du client {client2.Nom} créé en base");
    }
}
catch(ArgumentNullException ex)
{
    Console.WriteLine($"Impossible de créer la commande : {ex.Message}");
    return;
}
catch(ArgumentException ex)
{
    Console.WriteLine($"Impossible de créer la commande : {ex.Message}");
    return;
}
catch(InvalidOperationException ex)
{
    Console.WriteLine($"Impossible de créer la commande : {ex.Message}");
    return;
}
catch(Exception ex)
{
    Console.WriteLine($"Impossible de créer la commande : {ex.Message}");
    return;
}
//Lire et afficher toutes les commandes du client 2
var CmdCli2Base = context.Commandes
    .Include(p => p.Produit)
    .Where(p => p.Client.Id == client2.Id)
    .ToList();
Console.WriteLine($"Commandes du client {client2.Nom} : ");
foreach(var UneCmd in CmdCli2Base)
{
    UneCmd.AfficherDetails();
}



