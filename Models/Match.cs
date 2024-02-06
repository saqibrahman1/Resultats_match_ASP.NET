using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace scoreGr03.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Identifiant unique du match
        public DateTime DateHeure { get; set; } // Date et heure du match
        public int ScoreDomicile { get; set; } // Score de l'équipe domicile
        public int ScoreExterieur { get; set; } // Score de l'équipe extérieure
        public int? EquipeDomicileId { get; set; } // Identifiant de l'équipe domicile
        public virtual Equipe? EquipeDomicile { get; set; } // Navigation vers l'équipe domicile
        public int? EquipeExterieurId { get; set; } // Identifiant de l'équipe extérieure
        public virtual Equipe? EquipeExterieur { get; set; } // Navigation vers l'équipe extérieure
    
        public List<But>? Buts { get; set; }

    }
}
