using System.ComponentModel.DataAnnotations;

namespace GachaTracker.Models
{
    public class ZZZCharacter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Element { get; set; } // Physical, Fire, Ice, Electric, Ether

        [StringLength(50)]
        public string Faction { get; set; } // Attack, Stun, Support, Defense, Anomaly, Rupture

        [StringLength(10)]
        public string Rank { get; set; } // A Rank or S Rank

        public int CurrentLevel { get; set; } // Max 60

        [StringLength(100)]
        public string WEngineName { get; set; }

        public int WEngineLevel { get; set; } // Max 60

        public int SkillBasicAttack { get; set; } // Max 12

        public int SkillDodge { get; set; } // Max 12

        public int SkillAssist { get; set; } // Max 12

        public int SkillSpecialAttack { get; set; } // Max 12

        public int SkillChainAttack { get; set; } // Max 12

        public int SkillTalent { get; set; } // Max 6

        public int CoreSkillsCompleted { get; set; } // Additional skills 0-6
    }
}