using System.ComponentModel.DataAnnotations;

namespace GachaTracker.Models
{
    public class WutheringCharacter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Element { get; set; } // Aero, Havoc, Fusion, Glacio, Electro, Spectro

        public int Rarity { get; set; } // 4 or 5

        public int CurrentLevel { get; set; } // Max 90

        [StringLength(50)]
        public string WeaponType { get; set; } // Gauntlets, Broadblades, Swords, Pistols, Rectifiers

        [StringLength(100)]
        public string WeaponName { get; set; }

        public int WeaponLevel { get; set; } // Max 90

        public int SkillNormalAttack { get; set; } // Max 10

        public int SkillResonanceSkill { get; set; } // Max 10

        public int SkillForteCircuit { get; set; } // Max 10

        public int SkillResonanceLiberation { get; set; } // Max 10

        public int SkillIntroSkill { get; set; } // Max 10

        public int StatNodesCompleted { get; set; } // 0-10 additional level objects

        public int InherentSkillsCompleted { get; set; } // Talents 1-10

        [StringLength(100)]
        public string EchoSet { get; set; }

        public int EchoPieces { get; set; } // 0-5
    }
}