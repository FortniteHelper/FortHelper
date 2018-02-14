using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortHelper
{
    class ShowValue
    {
        public string Attribute { get; set; }
        public string Value { get; set; }

        public List<ShowValue> GetCollectionData(Weapon wData)
        {
            List<ShowValue> listValue = new List<ShowValue>();

            listValue.Add(new ShowValue()
            {
                Attribute = "Damage",
                Value = wData.DMG.ToString("0.0"),
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Critical Hit Chance",
                Value = $"{wData.CHC}%",
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Critical Hit Damage",
                Value = $"{wData.CHD}%",
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Headshot Damage",
                Value = $"{wData.Headshot}%",
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Fire Rate",
                Value = wData.FireRate.ToString("0.00"),
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Magazine Size",
                Value = wData.MagSize.ToString("0"),
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Range",
                Value = wData.Range.ToString(),
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Reload Time",
                Value = wData.Reload.ToString("0.0"),
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Ammo Cost",
                Value = wData.Ammo.ToString(),
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Impact",
                Value = wData.Impact.ToString("0.0"),
            });
            listValue.Add(new ShowValue()
            {
                Attribute = "Basic Damage Type",
                Value = wData.DamageType,
            });

            return listValue;
        }
    }
}
