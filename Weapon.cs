using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortHelper
{
    class Weapon
    {
        public string Name { get; set; }
        public string Quality { get; set; }
        public double DMG { get; set; }
        public int CHC { get; set; }
        public int CHD { get; set; }
        public int Headshot { get; set; }
        public double FireRate { get; set; }
        public double MagSize { get; set; }
        public int Range { get; set; }
        public double Reload { get; set; }
        public double Ammo { get; set; }
        public string AmmoType { get; set; }
        public double Impact { get; set; }
        public string DamageType { get; set; }
        public string WeaponType { get; set; }
        public bool bShadowshart { get; set; }

        public Weapon(DataRow drWeapon)
        {
            Name = drWeapon[1].ToString();
            Quality = drWeapon[2].ToString();
            DMG = Convert.ToDouble(drWeapon[3]);
            CHC = Convert.ToInt32(drWeapon[4]);
            CHD = Convert.ToInt32(drWeapon[5]);
            Headshot = Convert.ToInt32(drWeapon[6]);
            FireRate = Convert.ToDouble(drWeapon[7]);
            MagSize = Convert.ToDouble(drWeapon[8]);
            Range = Convert.ToInt32(drWeapon[9]);
            Reload = Convert.ToDouble(drWeapon[10]);
            Ammo = Convert.ToDouble(drWeapon[11]);
            AmmoType = drWeapon[12].ToString();
            Impact = Convert.ToDouble(drWeapon[13]);
            DamageType = drWeapon[14].ToString();
            WeaponType = drWeapon[15].ToString();
            bShadowshart = false;
        }
    }
}
