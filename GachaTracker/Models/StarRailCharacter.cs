using System.ComponentModel.DataAnnotations;

namespace GachaTracker.Models
{
    public class StarRailCharacter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Element { get; set; } // Physical, Fire, Ice, Lightning, Wind, Quantum, Imaginary

        [StringLength(50)]
        public string Path { get; set; } // Destruction, Hunt, Erudition, Harmony, Nihility, Preservation, Abundance, Remembrance

        public int Rarity { get; set; } // 4 or 5

        public int CurrentLevel { get; set; } // Max 80

        [StringLength(100)]
        public string LightconeName { get; set; }

        public int LightconeLevel { get; set; } // Max 80

        public int TalentBasicAttack { get; set; } // Max 6

        public int TalentSkill { get; set; } // Max 10

        public int TalentUltimate { get; set; } // Max 10

        public int TalentTalent { get; set; } // Max 10

        [StringLength(100)]
        public string RelicSet { get; set; }

        public int RelicPieces { get; set; } // 0-6
    }
}