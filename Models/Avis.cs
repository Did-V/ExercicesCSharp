namespace ExercicesCSharp.Models
{
    public class Avis
    {
        public int Id { get; set; }
        public Produit Produit { get; set; } = null!;
        public int Note { get; set; }
        public string Commentaire { get; set; } = null!;

        public Avis(Produit produit, int note, string commentaire)
        {
            if (produit == null)
            {
                throw new ArgumentNullException(nameof(produit), "Le produit ne peut pas être null.");
            }
            if (note < 1 || note > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(note), "La note doit être comprise entre 1 et 5.");
            }
            if (string.IsNullOrWhiteSpace(commentaire))
            {
                throw new ArgumentException("Le commentaire ne peut pas être vide ou null.", nameof(commentaire));
            }

            Produit = produit;
            Note = note;
            Commentaire = commentaire;
        }
    }
}