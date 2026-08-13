namespace ExercicesCSharp.Models
{
    public class Client
    {
        // public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateInscription { get; private set; } //Pourquoi private et non internal ? Parce que l'on ne veut pas que la date d'inscription soit modifiable depuis l'extérieur de la classe. Elle doit être définie uniquement lors de la création de l'objet Client.
        //Remarque différence entre private et internal : private signifie que la propriété ou la méthode est accessible uniquement à l'intérieur de la classe, tandis que internal signifie qu'elle est accessible à l'intérieur du même assembly (projet). Dans ce cas, nous voulons que la date d'inscription soit définie uniquement lors de la création de l'objet Client, donc nous utilisons private.
        public Client(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Le nom ne peut pas être vide ou null.", nameof(name));
            }
            //Vérifier si l'e-mail contient un @ seulement s'il est renseigné
            if (!string.IsNullOrWhiteSpace(email) && !email.Contains('@'))
            {
                throw new ArgumentException("L'e-mail doit contenir un '@'.", nameof(email));
            }
            
            Name = name;
            Email = email;
            DateInscription = DateTime.UtcNow;
        }
    }
}