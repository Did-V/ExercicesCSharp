using ExercicesCSharp.Models;

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
    Console.WriteLine($"Client créé : {client.Name}, {client.Email}, {client.DateInscription}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erreur lors de la création du client : {ex.Message}");
}
//Client sans e-mail :  pas d'erreur
try
{
    Client clientSansEmail = new("Jean", "");
    Console.WriteLine($"Client créé : {clientSansEmail.Name}, {clientSansEmail.Email}, {clientSansEmail.DateInscription}");
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