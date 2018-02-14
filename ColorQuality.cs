using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FortHelper
{
    public class ColorQuality
    {
        static Color colorLegendary = Color.FromArgb(255, 200, 100, 0);
        static Color colorDarkLegendary = Color.FromArgb(255, 160, 80, 50);

        static Color colorEpic = Color.FromArgb(255, 120, 40, 210);
        static Color colorDarkEpic = Color.FromArgb(255, 80, 20, 120);

        static Color colorRare = Color.FromArgb(255, 30, 120, 160);
        static Color colorDarkRare = Color.FromArgb(255, 20, 70, 100);

        static Color colorUncommon = Color.FromArgb(255, 0, 130, 70);
        static Color colorDarkUncommon = Color.FromArgb(255, 0, 70, 40);

        static Color colorCommon = Color.FromArgb(255, 100, 100, 100);
        static Color colorDarkCommon = Color.FromArgb(255, 70, 70, 70);

        public static List<Color> GetColor(string sQuality)
        {
            List<Color> listColor = new List<Color>();
            switch(sQuality)
            {
                case "Legendary":
                    listColor.Add(colorLegendary);
                    listColor.Add(colorDarkLegendary);
                    break;
                case "Epic":
                    listColor.Add(colorEpic);
                    listColor.Add(colorDarkEpic);
                    break;
                case "Rare":
                    listColor.Add(colorRare);
                    listColor.Add(colorDarkRare);
                    break;
                case "Uncommon":
                    listColor.Add(colorUncommon);
                    listColor.Add(colorDarkUncommon);
                    break;
                case "Common":
                    listColor.Add(colorCommon);
                    listColor.Add(colorDarkCommon);
                    break;
            }
            return listColor;
        }
    }
}
