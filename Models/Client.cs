namespace ExercicesCSharp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public DateTime DateInscription { get; private set; } //Pourquoi private et non internal ? Parce que l'on ne veut pas que la date d'inscription soit modifiable depuis l'extérieur de la classe. Elle doit être définie uniquement lors de la création de l'objet Client.
        //Remarque différence entre private et internal : private signifie que la propriété ou la méthode est accessible uniquement à l'intérieur de la classe, tandis que internal signifie qu'elle est accessible à l'intérieur du même assembly (projet). Dans ce cas, nous voulons que la date d'inscription soit définie uniquement lors de la création de l'objet Client, donc nous utilisons private.
        public Client(string nom, string email)
        {
            if (string.IsNullOrWhiteSpace(nom))
            {
                throw new ArgumentException("Le nom ne peut pas être vide ou null.", nameof(nom));
            }
            //Vérifier si l'e-mail contient un @ seulement s'il est renseigné
            if (!string.IsNullOrWhiteSpace(email) && !email.Contains('@'))
            {
                throw new ArgumentException($"L'e-mail du client {nom} doit contenir un '@'.", nameof(email));
            }
            
            Nom = nom;
            Email = email;
            DateInscription = DateTime.UtcNow;
        }

        public static bool EstNouveauClient(DateTime dateInscription) //Pourquoi static ? Parce que cette méthode ne dépend pas d'une instance de la classe Client. Elle peut être appelée sans créer un objet Client. Elle prend en paramètre une date d'inscription et retourne un booléen indiquant si le client est nouveau ou non.
        //Que veut dire "ne dépend pas d'une instance" ? Cela signifie que la méthode peut être appelée sur la classe elle-même, sans avoir besoin de créer une instance de cette classe.
        {
            //Un client est considéré comme nouveau s'il a été créé il y a moins de 30 jours
            return (DateTime.UtcNow - dateInscription).TotalDays < 30;
        }

        public static int DiviserNombre(int nombre, int diviseur)
        {
            if (diviseur == 0)
            {
                throw new DivideByZeroException("Le diviseur ne peut pas être zéro.");
            }
            return nombre / diviseur;
        }
    }
}