using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortHelper
{
    public enum PerkQuality { Common, Rare, Legendary, OnlyOneValue}

    public class Perk
    {
        public PerkQuality PerkQuality { get; set; }
        public string Name { get; set; }
        public double DMG { get; set; }
        public double CHC { get; set; }
        public double CHD { get; set; }
        public double Headshot { get; set; }
        public double FireRate { get; set; }
        public double MagSize { get; set; }
        public double Reload { get; set; }
        public double Recoil { get; set; }
        public double Durability { get; set; }
        public double DMGRequirement { get; set; }
        public double DMGElement { get; set; }
        public string DMGType { get; set; }

        public Perk(PerkQuality perkQuality)
        {
            int iQuality = (int)perkQuality;

            if (perkQuality != PerkQuality.OnlyOneValue)
            {
                PerkQuality = perkQuality;
                Name = "All";
                DMG = 10 + (iQuality * 5);
                CHC = 14 + (iQuality * 7);
                CHD = 30 + (iQuality * 15);
                Headshot = 13.3d + (iQuality * 6.7d);
                FireRate = 12 + (iQuality * 6);
                MagSize = 30 + (iQuality * 15);
                Reload = 15 + (iQuality * 7.5d);
                Recoil = 20 + (iQuality * 10);
                Durability = 7 + (iQuality * 5);
                DMGRequirement = 15 + (iQuality * 7.5d);
                DMGElement = 10;
                DMGType = "Physically";
            }
        }

        public List<Perk> PicList()
        {
            List<Perk> lpPerkList = new List<Perk>();

            //Perk
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = "Nothing" });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{DMG}% Damage", DMG = this.DMG });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{CHC}% Crit Chance", CHC = this.CHC });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{CHD}% Crit Damage", CHD = this.CHD });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{Headshot}% Headshot Damage", Headshot = this.Headshot });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{FireRate}% Fire Rate", FireRate = this.FireRate });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{MagSize}% Magazine Size", MagSize = this.MagSize });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{Reload}% Reload Speed", Reload = this.Reload });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"-{Recoil}% Recoil", Recoil = this.Recoil });
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{Durability}% Longer Durability", Durability = this.Durability });

            //Perk with Requirement
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{DMGRequirement}% Damage to afflicted targets", DMGRequirement = this.DMGRequirement});
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{DMGRequirement}% Damage to stunned, staggered and knocked down targets", DMGRequirement = this.DMGRequirement});
            lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+{DMGRequirement}% Damage to slowed and snared targets", DMGRequirement = this.DMGRequirement});

            //Perk Element
            switch (PerkQuality)
            {
                case PerkQuality.Common:
                    lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+10% Damage. Causes Affliction damage for 6 seconds.", DMGElement = this.DMGElement });
                    break;
                case PerkQuality.Rare:
                    lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+10% Weapon Damage (Fire)", DMGElement = this.DMGElement, DMGType = "Fire"});
                    lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+10% Weapon Damage (Water)", DMGElement = this.DMGElement, DMGType = "Water" });
                    lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+10% Weapon Damage (Nature)", DMGElement = this.DMGElement, DMGType = "Nature" });
                    break;
                case PerkQuality.Legendary:
                    lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+10% Weapon Damage (Fire). Causes Affliction damage for 6 seconds.", DMGElement = this.DMGElement, DMGType = "Fire" });
                    lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+10% Weapon Damage (Water). Causes Affliction damage for 6 seconds.", DMGElement = this.DMGElement, DMGType = "Water" });
                    lpPerkList.Add(new Perk(PerkQuality.OnlyOneValue) { Name = $"+10% Weapon Damage (Nature). Causes Affliction damage for 6 seconds.", DMGElement = this.DMGElement, DMGType = "Nature" });
                    break;
            }

            return lpPerkList;
        }

        public Perk SummuaryPerk(Perk Perk1, Perk Perk2, Perk Perk3, Perk Perk4, Perk Perk5)
        {
            Perk Perk6 = new Perk(PerkQuality.OnlyOneValue);
            Perk Perk7 = new Perk(PerkQuality.OnlyOneValue);

            if (Perk2 == null)
                Perk2 = new Perk(PerkQuality.OnlyOneValue);
            if (Perk3 == null)
                Perk3 = new Perk(PerkQuality.OnlyOneValue);
            if (Perk4 == null)
                Perk4 = new Perk(PerkQuality.OnlyOneValue);
            if (Perk5 == null)
                Perk5 = new Perk(PerkQuality.OnlyOneValue);
            if (Perk6 == null)
                Perk6 = new Perk(PerkQuality.OnlyOneValue);
            if (Perk7 == null)
                Perk7 = new Perk(PerkQuality.OnlyOneValue);

            Perk perkSum = new Perk(PerkQuality.OnlyOneValue);

            perkSum.CHC = Perk1.CHC + Perk2.CHC + Perk3.CHC + Perk4.CHC + Perk5.CHC + Perk6.CHC + Perk7.CHC;
            perkSum.CHD = Perk1.CHD + Perk2.CHD + Perk3.CHD + Perk4.CHD + Perk5.CHD + Perk6.CHD + Perk7.CHD;
            perkSum.DMG = Perk1.DMG + Perk2.DMG + Perk3.DMG + Perk4.DMG + Perk5.DMG + Perk6.DMG + Perk7.DMG;
            perkSum.Durability = Perk1.Durability + Perk2.Durability + Perk3.Durability + Perk4.Durability + Perk5.Durability + Perk6.Durability + Perk7.Durability;
            perkSum.FireRate = Perk1.FireRate + Perk2.FireRate + Perk3.FireRate + Perk4.FireRate + Perk5.FireRate + Perk6.FireRate + Perk7.FireRate;
            perkSum.Headshot = Perk1.Headshot + Perk2.Headshot + Perk3.Headshot + Perk4.Headshot + Perk5.Headshot + Perk6.Headshot + Perk7.Headshot;
            perkSum.MagSize = Perk1.MagSize + Perk2.MagSize + Perk3.MagSize + Perk4.MagSize + Perk5.MagSize + Perk6.MagSize + Perk7.MagSize;
            perkSum.Recoil = Perk1.Recoil + Perk2.Recoil + Perk3.Recoil + Perk4.Recoil + Perk5.Recoil + Perk6.Recoil + Perk7.Recoil;
            perkSum.Reload = Perk1.Reload + Perk2.Reload + Perk3.Reload + Perk4.Reload + Perk5.Reload + Perk6.Reload + Perk7.Reload;
            perkSum.DMGRequirement = Perk1.DMGRequirement + Perk2.DMGRequirement + Perk3.DMGRequirement + Perk4.DMGRequirement + Perk5.DMGRequirement + Perk6.DMGRequirement + Perk7.DMGRequirement;
            perkSum.DMGElement = Perk1.DMGElement + Perk2.DMGElement + Perk3.DMGElement + Perk4.DMGElement + Perk5.DMGElement + Perk6.DMGElement + Perk7.DMGElement;

            //Set DamageType
            perkSum.DMGType = Perk1.DMGType;
            if(Perk2.DMGType != null)
                perkSum.DMGType = Perk2.DMGType;
            else if (Perk3.DMGType != null)
                perkSum.DMGType = Perk3.DMGType;
            else if (Perk4.DMGType != null)
                perkSum.DMGType = Perk4.DMGType;
            else if (Perk5.DMGType != null)
                perkSum.DMGType = Perk5.DMGType;

            return perkSum;
        }

    }
}
