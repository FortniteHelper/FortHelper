using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortHelper
{
    public class DPSValue
    {
        private double _dDPSFire;
        private double _dDPSNature;
        private double _dDPSWater;
        private double _dDPSNormal;

        public double DPSFire { get => _dDPSFire; set => _dDPSFire = value; }
        public double DPSNature { get => _dDPSNature; set => _dDPSNature = value; }
        public double DPSWater { get => _dDPSWater; set => _dDPSWater = value; }
        public double DPSNormal { get => _dDPSNormal; set => _dDPSNormal = value; }

        public DPSValue(double dDPSFire, double dDPSNature, double dDPSWater, double dDPSNormal)
        {
            _dDPSFire = dDPSFire;
            _dDPSNature = dDPSNature;
            _dDPSWater = dDPSWater;
            _dDPSNormal = dDPSNormal;
        }
    }

    public class DPSValueList : ObservableCollection<DPSValue>
    {
        public DPSValueList() : base()
        {
            Add(new DPSValue(DPS.DPSFire(DPS.Weapon1, DPS.PerkPacket1), DPS.DPSNature(DPS.Weapon1, DPS.PerkPacket1), DPS.DPSWater(DPS.Weapon1, DPS.PerkPacket1), DPS.TrueDPS(DPS.Weapon1, DPS.PerkPacket1)));
        }
    }
}
