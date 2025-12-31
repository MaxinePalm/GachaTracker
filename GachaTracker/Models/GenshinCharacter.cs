using System.ComponentModel.DataAnnotations;

namespace GachaTracker.Models
{
    public class GenshinCharacter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Element { get; set; } // Pyro, Cryo, Hydro, Dendro, Geo, Electro, Anemo

        public int Rarity { get; set; } // 4 or 5

        public int CurrentLevel { get; set; } // Max 90

        [StringLength(50)]
        public string WeaponType { get; set; } // Catalyst, Sword, Claymore, Polearm, Bow

        [StringLength(100)]
        public string WeaponName { get; set; }

        public int WeaponLevel { get; set; } // Max 90

        public int TalentBasicAttack { get; set; } // Max 10

        public int TalentSkill { get; set; } // Max 10

        public int TalentUltimate { get; set; } // Max 10

        [StringLength(100)]
        public string ArtifactSet { get; set; }

        public int ArtifactsPieces { get; set; } // 0-5
    }
}