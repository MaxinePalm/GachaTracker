using System.ComponentModel.DataAnnotations;

namespace GachaTracker.Models
{
    public class EndfieldCharacter
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Element Type: Cryo, Heat, Physical, Nature, Electric
        [Required]
        public string ElementType { get; set; } = string.Empty;

        // Sub Class: Guard, Caster, Striker, Vanguard, Defender, Supporter
        [Required]
        public string SubClass { get; set; } = string.Empty;

        // Weapon Type: Sword, Greatsword, Polearm, Handcannon, Arts Unit
        [Required]
        public string WeaponType { get; set; } = string.Empty;

        // Character Level (1-90)
        [Range(1, 90)]
        public int CharacterLevel { get; set; } = 1;

        // Weapon Level (1-90)
        [Range(1, 90)]
        public int WeaponLevel { get; set; } = 1;

        // Trust Talent Nodes (4 nodes)
        public bool TrustTalent1 { get; set; } = false;
        public bool TrustTalent2 { get; set; } = false;
        public bool TrustTalent3 { get; set; } = false;
        public bool TrustTalent4 { get; set; } = false;

        // Talents Under Trust (4 talents)
        public bool UnderTrustTalent1 { get; set; } = false;
        public bool UnderTrustTalent2 { get; set; } = false;
        public bool UnderTrustTalent3 { get; set; } = false;
        public bool UnderTrustTalent4 { get; set; } = false;

        // Ship Talents (4 talents)
        public bool ShipTalent1 { get; set; } = false;
        public bool ShipTalent2 { get; set; } = false;
        public bool ShipTalent3 { get; set; } = false;
        public bool ShipTalent4 { get; set; } = false;

        // Promotions (4 promotions - unlocks level caps)
        [Range(0, 4)]
        public int PromotionLevel { get; set; } = 0;

        // Outfitting (4 levels - enables higher level artifacts)
        [Range(0, 4)]
        public int OutfittingLevel { get; set; } = 0;

        // Main Talents (4 talents, each rank 1-9)
        [Range(1, 9)]
        public int MainTalent1 { get; set; } = 1;

        [Range(1, 9)]
        public int MainTalent2 { get; set; } = 1;

        [Range(1, 9)]
        public int MainTalent3 { get; set; } = 1;

        [Range(1, 9)]
        public int MainTalent4 { get; set; } = 1;

        // Calculated Properties
        public int TotalTrustTalentsUnlocked =>
            (TrustTalent1 ? 1 : 0) +
            (TrustTalent2 ? 1 : 0) +
            (TrustTalent3 ? 1 : 0) +
            (TrustTalent4 ? 1 : 0);

        public int TotalUnderTrustTalentsUnlocked =>
            (UnderTrustTalent1 ? 1 : 0) +
            (UnderTrustTalent2 ? 1 : 0) +
            (UnderTrustTalent3 ? 1 : 0) +
            (UnderTrustTalent4 ? 1 : 0);

        public int TotalShipTalentsUnlocked =>
            (ShipTalent1 ? 1 : 0) +
            (ShipTalent2 ? 1 : 0) +
            (ShipTalent3 ? 1 : 0) +
            (ShipTalent4 ? 1 : 0);

        public int TotalMainTalentRanks =>
            MainTalent1 + MainTalent2 + MainTalent3 + MainTalent4;

        public int MaxCharacterLevel
        {
            get
            {
                return PromotionLevel switch
                {
                    0 => 30,
                    1 => 45,
                    2 => 60,
                    3 => 75,
                    4 => 90,
                    _ => 30
                };
            }
        }
    }
}
