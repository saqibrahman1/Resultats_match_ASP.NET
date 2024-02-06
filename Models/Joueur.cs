using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace scoreGr03.Models
{
    public class Joueur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Identifiant unique du joueur
        public string Nom { get; set; } // Nom du joueur
        public string Prenom { get; set; } // Prénom du joueur
        public int EquipeId { get; set; }
        public Equipe? Equipe { get; set; }

    }
}
