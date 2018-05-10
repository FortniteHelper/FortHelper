using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortHelper
{
    public enum ElementType { Fire, Water, Nature, Energy}

    class DPS
    {
        static private Weapon _Weapon1;
        static private Weapon _Weapon2;
        static private Weapon _Weapon3;

        static private Perk _PerkPacket1;
        static private Perk _PerkPacket2;
        static private Perk _PerkPacket3;

        public static Perk PerkPacket1 { get => _PerkPacket1; set => _PerkPacket1 = value; }
        public static Perk PerkPacket2 { get => _PerkPacket2; set => _PerkPacket2 = value; }
        public static Perk PerkPacket3 { get => _PerkPacket3; set => _PerkPacket3 = value; }

        public static Weapon Weapon1 { get => _Weapon1; set => _Weapon1 = value; }
        public static Weapon Weapon2 { get => _Weapon2; set => _Weapon2 = value; }
        public static Weapon Weapon3 { get => _Weapon3; set => _Weapon3 = value; }

        static public double TrueDPS(Weapon myWeapon, Perk myPerk)
        {
            if (myPerk != null)
            {
                double iDmgShadowshart = 0;
                double iFirerateShadowshart = 0;
                if (myWeapon.bShadowshart)
                {
                    iDmgShadowshart = 20d;
                    iFirerateShadowshart = -10d;
                }

                //Set all Bonus.
                int iTime = 60;
                //myWeapon.Headshot = 50;
                double ShootMag = Math.Floor(myWeapon.MagSize * (1 + (myPerk.MagSize / 100d)) / myWeapon.Ammo);
                double DMGMulti = 1 + ((myPerk.DMG + myPerk.DMGRequirement + myPerk.DMGElement + iDmgShadowshart) / 100d);
                double FireRate = myWeapon.FireRate * (1 + ((myPerk.FireRate + iFirerateShadowshart) / 100d));
                double Reload = myWeapon.Reload / (1 + (myPerk.Reload / 100D));
                double HeadShoot = 1 + ((myWeapon.Headshot + myPerk.Headshot) / 100d);
                double CHC = (myWeapon.CHC + myPerk.CHC) / 100d;
                if (CHC > 1)
                    CHC = 1;
                double CHD = (myWeapon.CHD + myPerk.CHD) / 100d;

                //Calc DPS with no Element.
                double dps = iTime / (ShootMag / FireRate + Reload) * (ShootMag * myWeapon.DMG) / iTime;
                dps = (ShootMag * myWeapon.DMG) / (ShootMag / FireRate + Reload);
                //double dpsWithMulti = dps * DMGMulti * (HeadShoot * (1 + CHC * CHD));
                double dpsWithMulti = dps * DMGMulti * (HeadShoot + (CHC * CHD));

                //Calc DPS with Element.    
                //DPSElement(Math.Round(dpsWithMulti, 2), myWeapon.DamageType, myPerk.DMGType);

                //DPS TEST
                // Final Damage = Base Damage
                //* (1 + (Evolutions - 1) * 0.2)
                //* (1 + (Weapon Level - 1 ) *0.05)  
                //* (1 + Perk Damage + Hero Perk Damage)  
                //* (1 + Offense / 100)
                //* Damage difference due to elements
                double FinalDPS = myWeapon.DMG
                                  * (1 + (1 - 1) * 0.2)
                                  * (1 + (2 - 1) * 0.05);

                return Math.Round(dpsWithMulti, 2);
            }
            return 0;
        }

        static public double DPSFire(Weapon myWeapon, Perk myPerk)
        {
            double dDPS = TrueDPS(myWeapon, myPerk);

            double dBase = 0.5;
            double dWater = 0.5;
            double dNature = -0.25;
            double dFire = 0.167;
            double dEnergy = 0.167;
            double dSum = 0.5;

            if (myPerk != null)
            {
                switch (myWeapon.DamageType)
                {
                    case "Nature":
                        dSum += dNature;
                        break;
                    case "Fire":
                        dSum += dFire;
                        break;
                    case "Water":
                        dSum += dWater;
                        break;
                    case "Energy":
                        dSum += dEnergy;
                        break;
                }

                if (myWeapon.DamageType != myPerk.DMGType && myPerk.DMGType != null)
                {
                    switch (myPerk.DMGType)
                    {
                        case "Nature":
                            dSum += dNature;
                            break;
                        case "Fire":
                            dSum += dFire;
                            break;
                        case "Water":
                            dSum += dWater;
                            break;
                        case "Energy":
                            dSum += dEnergy;
                            break;
                    }
                }
                return Math.Round(dDPS * dSum, 2);
            }
            return 0;
        }

        static public double DPSWater(Weapon myWeapon, Perk myPerk)
        {
            double dDPS = TrueDPS(myWeapon, myPerk);

            double dBase = 0.5;
            double dWater = 0.167;
            double dNature = 0.5;
            double dFire = -0.25;
            double dEnergy = 0.167;
            double dSum = 0.5;

            if (myPerk != null)
            {
                switch (myWeapon.DamageType)
                {
                    case "Nature":
                        dSum += dNature;
                        break;
                    case "Fire":
                        dSum += dFire;
                        break;
                    case "Water":
                        dSum += dWater;
                        break;
                    case "Energy":
                        dSum += dEnergy;
                        break;
                }

                if (myWeapon.DamageType != myPerk.DMGType && myPerk.DMGType != null)
                {
                    switch (myPerk.DMGType)
                    {
                        case "Nature":
                            dSum += dNature;
                            break;
                        case "Fire":
                            dSum += dFire;
                            break;
                        case "Water":
                            dSum += dWater;
                            break;
                        case "Energy":
                            dSum += dEnergy;
                            break;
                    }
                }
                return Math.Round(dDPS * dSum, 2);
            }
            return 0;
        }

        static public double DPSNature(Weapon myWeapon, Perk myPerk)
        {
            double dDPS = TrueDPS(myWeapon, myPerk);

            double dBase = 0.5;
            double dWater = -0.25;
            double dNature = 0.167;
            double dFire = 0.5;
            double dEnergy = 0.167;
            double dSum = 0.5;

            if (myPerk != null)
            {
                switch (myWeapon.DamageType)
                {
                    case "Nature":
                        dSum += dNature;
                        break;
                    case "Fire":
                        dSum += dFire;
                        break;
                    case "Water":
                        dSum += dWater;
                        break;
                    case "Energy":
                        dSum += dEnergy;
                        break;
                }

                if (myWeapon.DamageType != myPerk.DMGType && myPerk.DMGType != null)
                {
                    switch (myPerk.DMGType)
                    {
                        case "Nature":
                            dSum += dNature;
                            break;
                        case "Fire":
                            dSum += dFire;
                            break;
                        case "Water":
                            dSum += dWater;
                            break;
                        case "Energy":
                            dSum += dEnergy;
                            break;
                    }
                }
                return Math.Round(dDPS * dSum, 2);
            }
            return 0;
        }
    }
}
