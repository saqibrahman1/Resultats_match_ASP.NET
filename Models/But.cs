using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace scoreGr03.Models
{
    public class But
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Identifiant unique du but
        public string Temps { get; set; } // Temps du but pendant le match 
        public int JoueurId { get; set; } 

        public  Joueur? Joueur { get; set; }
    public int MatchId { get; set; } // Identifiant du match où le but a été marqué
    public Match? Match { get; set; }
}
}


