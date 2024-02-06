using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace scoreGr03.Models
{
    public class Equipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Identifiant unique de l'équipe
        public string Nom { get; set; } // Nom de l'équipe
        public string Logo { get; set; } // URL ou chemin d'accès vers le logo de l'équipe
        public List<Joueur>? Joueurs { get; set; } // Liste des identifiants des joueurs de l'équipe
    }
}
