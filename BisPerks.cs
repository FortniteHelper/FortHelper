using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortHelper
{
    class BisPerks
    {
        List<int> ListBinär = new List<int>();

        public BisPerks(Weapon bisWeapon)
        {
            //string[] Variationen = GetPermutation(3, new char[] { '1', '2', '3' });
            //string[] Variationen = GetPermutation(3, new char[] { '1', '2', '3', '4', '5' });
            Perk myPerk = new Perk(PerkQuality.Legendary);
            List<Perk> listPerk = myPerk.PicList();
            int[] iCombos = new int[listPerk.Count];
            for (int i = 0; i < listPerk.Count; i++)
            {
                iCombos[i] = i;
            }
            //string[] sVariationen = GetPermutation(4, iCombos);

            //CalcDPS(bisWeapon, sVariationen);
        }

        public static string[] GetPermutation(int iPlaces, int[] iNumbers)
        {
            // Eine neue, leere ArrayList generieren, an die alle Möglichkeiten angehängt werden
            ArrayList output = new ArrayList();
            GetPermutationPerRef(iPlaces, iNumbers, ref output);

            // Das Ergebnis in einen string[] umwandeln und zurückgeben
            return output.ToArray(typeof(string)) as string[];

        }

        private static void GetPermutationPerRef(int places, int[] iNumbers, ref ArrayList output, string outputPart = "")
        {
            if (places == 0)
            {
                // Wenn die Anzahl der Stellen durchgerechnet wurde,
                // wird der sich ergebende string (Element) an die Ausgabe angehängt.
                output.Add(outputPart);
            }
            else
            {
                // Für die Stelle rechts im Element, werden alle Zeichenmöglichkeiten durchlaufen
                foreach (int i in iNumbers)
                {
                    // Danach wird für jedes dieser Zeichen, basierend auf der Anzahl der Stellen, wieder ein neuer
                    // foreach-Vorgang begonnen, der alle Zeichen der nächsten Stelle hinzufügt

                    GetPermutationPerRef(places - 1,   // Die Stellen Anzahl wird verwindert, bis 0
                        iNumbers,                         // Benötigte Variablen werden
                        ref output,                    // mitübergeben
                        outputPart + i + ",");               // An diesen letzen string werden alle anderen Stellen angehängt
                }
            }
        }

        private void CalcDPS(Weapon myWeapon, string[] sVariatonen)
        {
            Perk myPerk = new Perk(PerkQuality.Legendary);
            Perk myPerkLvL1 = new Perk(PerkQuality.Legendary);
            List<Perk> listPerk = myPerk.PicList();
            char[] charSplit = new char[] { ',' };
            double dDPSHigh = 0;
            int[] iComboHigh = new int[5];

            foreach (string sCombo in sVariatonen)
            {
                string[] sComboArray = sCombo.Split(charSplit, StringSplitOptions.RemoveEmptyEntries);
                int[] iCombo = new int[5];

                for (int i = 0; i < sComboArray.Length; i++)
                {
                    iCombo[i] = System.Convert.ToInt32(sComboArray[i]);
                }

                Perk perk1 = listPerk[iCombo[0]];
                Perk perk2 = listPerk[iCombo[1]];
                Perk perk3 = listPerk[iCombo[2]];
                Perk perk4 = listPerk[iCombo[3]];
                //Perk perk5 = listPerk[iCombo[4]];
                Perk perk5 = myPerkLvL1.PicList()[13];
                //Perk perk6 = new Perk(HeroMain.UrbanAssault);
                //Perk perk7 = new Perk(HeroSup.AssaultCritDamage);
                //Perk perk6 = new Perk(HeroMain.Nothing);
                //Perk perk7 = new Perk(HeroMain.Nothing);

                Perk PerkSum = perk1.SummuaryPerk(perk1, perk2, perk3, perk4, perk5);
                double dDPS = DPS.TrueDPS(myWeapon, PerkSum);

                if (dDPS > dDPSHigh)
                {
                    dDPSHigh = dDPS;
                    iComboHigh = iCombo;
                }
            }
        }

        public void CalcBestDPS(Weapon myWeapon, int[] iSelectedPerk, PerkQuality[] perkLvLSelected)
        {
            double dDPSHigh = 0;
            int[] iPerkBest = new int[5];
            List<Perk> listPerkCommon = new Perk(PerkQuality.Common).PicList();
            List<Perk> listPerkRare = new Perk(PerkQuality.Rare).PicList();
            List<Perk> listPerkLegendary = new Perk(PerkQuality.Legendary).PicList();
            int iTempSelectedPerk = 0;
            PerkQuality perkTempQuality = PerkQuality.Common;

            for (int iCurrentReroll = 0; iCurrentReroll < 5; iCurrentReroll++)
            {
                iTempSelectedPerk = iSelectedPerk[iCurrentReroll];
                perkTempQuality = perkLvLSelected[iCurrentReroll];
                for (int iListPerks = 0; iListPerks < listPerkLegendary.Count; iListPerks++)
                {
                    iSelectedPerk[iCurrentReroll] = iListPerks;
                    perkLvLSelected[iCurrentReroll] = PerkQuality.Legendary;

                    Perk[] perkSelected = new Perk[5];
                    for (int iPerksCalc = 0; iPerksCalc < 5; iPerksCalc++)
                    {
                        switch (perkLvLSelected[iPerksCalc])
                        {
                            case PerkQuality.Common:
                                perkSelected[iPerksCalc] = listPerkCommon[iSelectedPerk[iPerksCalc]];
                                break;
                            case PerkQuality.Rare:
                                perkSelected[iPerksCalc] = listPerkRare[iSelectedPerk[iPerksCalc]];
                                break;
                            case PerkQuality.Legendary:
                                perkSelected[iPerksCalc] = listPerkLegendary[iSelectedPerk[iPerksCalc]];
                                break;
                        }
                    }
                    Perk perkSum = perkSelected[0].SummuaryPerk(perkSelected[0], perkSelected[1], perkSelected[2], perkSelected[3], perkSelected[4]);
                    double dDPS = DPS.TrueDPS(myWeapon, perkSum);
                    if (dDPS > dDPSHigh)
                    {
                        dDPSHigh = dDPS;
                        iSelectedPerk.CopyTo(iPerkBest,0);
                    }
                }
                iSelectedPerk[iCurrentReroll] = iTempSelectedPerk;
                perkLvLSelected[iCurrentReroll] = perkTempQuality;
            }
        }
    }
}
