using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FortHelper
{
    /// <summary>
    /// Interaction logic for WinDPS.xaml
    /// </summary>
    public partial class WinDPS : Window
    {
        public WinDPS()
        {
            InitializeComponent();

            FillcobWeapon();
        }

        private void FillcobWeapon()
        {
            DataSet dsWeapon = DBWeapons.GetWeapon();

            //Weapon1
            cobWeapon.ItemsSource = dsWeapon.Tables[0].DefaultView;
            cobWeapon.DisplayMemberPath = "Name";

        }

        private void LoadDataFromWebsite(string sEpicName)
        {
            LoadWeaponWebsite myWeapons = new LoadWeaponWebsite(sEpicName);
            dgvInventory.ItemsSource = myWeapons.GetAllRangeWeapon();
        }

        private void cobWeapon_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox cbWeapon = sender as ComboBox;
            DataRowView rowView = cbWeapon.SelectedItem as DataRowView;
            DataRow rowData = rowView.Row;

            Weapon wPickWeapon = new Weapon(rowData);
            ColorChange(wPickWeapon);
            SetLabel(wPickWeapon);
            DPS.Weapon1 = wPickWeapon;
            ShowValue showValue = new ShowValue();
            dagWeapon1.ItemsSource = showValue.GetCollectionData(wPickWeapon);

            if (chbShadow.IsChecked.Value)
                DPS.Weapon1.bShadowshart = true;
            else
                DPS.Weapon1.bShadowshart = false;

            dagDPS.ItemsSource = new DPSValueList();
        }

        private void SetLabel(Weapon wLoadWeapon)
        {
            lblQuality.Content = wLoadWeapon.Quality;
            lblWeaponType.Content = $"Ranged | {wLoadWeapon.WeaponType}";
        }

        private void ColorChange(Weapon wLoadWeapon)
        {
            List<Color> newColor = ColorQuality.GetColor(wLoadWeapon.Quality);

            this.Resources["QualityColor"] = newColor[0];
            this.Resources["QualityDarkColor"] = newColor[1];
        }

        private void cobLvLX_ColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color> e)
        {
            PerkLvlPicker plpUsePicker = sender as PerkLvlPicker;
            Color mycolor = plpUsePicker.SelectedColor;

            //if(mycolor.Equals(Colors.LightGray))
            //{
            //    ShowPerkName(plpUsePicker.Name, PerkQuality.Common);
            //}
            //else if(mycolor.Equals(Colors.DodgerBlue))
            //{
            //    ShowPerkName(plpUsePicker.Name, PerkQuality.Rare);
            //}
            //else if(mycolor.Equals(Colors.DarkOrange))
            //{
            //    ShowPerkName(plpUsePicker.Name, PerkQuality.Legendary);
            //}
            ShowPerkName(plpUsePicker.Name, plpUsePicker.SelectedPerkQuality);
        }

        private void ShowPerkName(string sNameLvlPicker, PerkQuality perkQuality)
        {
            List<Perk> listPerk = new List<Perk>();
            switch(perkQuality)
            {
                case PerkQuality.Common:
                    listPerk = new Perk(PerkQuality.Common).PicList();
                    break;
                case PerkQuality.Rare:
                    listPerk = new Perk(PerkQuality.Rare).PicList();
                    break;
                case PerkQuality.Legendary:
                    listPerk = new Perk(PerkQuality.Legendary).PicList();
                    break;
            }


            switch(sNameLvlPicker)
            {
                case "cobLvL1":
                    cobPerk1.ItemsSource = listPerk;
                    cobPerk1.DisplayMemberPath = "Name";
                    break;
                case "cobLvL2":
                    cobPerk2.ItemsSource = listPerk;
                    cobPerk2.DisplayMemberPath = "Name";
                    break;
                case "cobLvL3":
                    cobPerk3.ItemsSource = listPerk;
                    cobPerk3.DisplayMemberPath = "Name";
                    break;
                case "cobLvL4":
                    cobPerk4.ItemsSource = listPerk;
                    cobPerk4.DisplayMemberPath = "Name";
                    break;
                case "cobLvL5":
                    cobPerk5.ItemsSource = listPerk;
                    cobPerk5.DisplayMemberPath = "Name";
                    break;
            }

        }

        private void cobPerkX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Perk perk1 = cobPerk1.SelectedItem as Perk;
            Perk perk2 = cobPerk2.SelectedItem as Perk;
            Perk perk3 = cobPerk3.SelectedItem as Perk;
            Perk perk4 = cobPerk4.SelectedItem as Perk;
            Perk perk5 = cobPerk5.SelectedItem as Perk;

            if(perk1 == null)
                perk1 = new Perk(PerkQuality.OnlyOneValue);

            DPS.PerkPacket1 = perk1.SummuaryPerk(perk1, perk2, perk3, perk4, perk5);
            dagDPS.ItemsSource = new DPSValueList();
        }

        private void chbShadow_Click(object sender, RoutedEventArgs e)
        {
            if (chbShadow.IsChecked.Value)
                DPS.Weapon1.bShadowshart = true;
            else
                DPS.Weapon1.bShadowshart = false;

            dagDPS.ItemsSource = new DPSValueList();
        }

        private void SelectWeaponAndPerks()
        {
            LoadWeaponWebsite weaponWebsite = (LoadWeaponWebsite)dgvInventory.SelectedItem;

            List<Perk> listPerkCommon = new Perk(PerkQuality.Common).PicList();
            List<Perk> listPerkRare = new Perk(PerkQuality.Rare).PicList();
            List<Perk> listPerkLegendary = new Perk(PerkQuality.Legendary).PicList();

            List<PerkLvlPicker> listcobLvLX = new List<PerkLvlPicker>();
            listcobLvLX.Add(cobLvL1);
            listcobLvLX.Add(cobLvL2);
            listcobLvLX.Add(cobLvL3);
            listcobLvLX.Add(cobLvL4);
            listcobLvLX.Add(cobLvL5);
            List<ComboBox> listcobPerkX = new List<ComboBox>();
            listcobPerkX.Add(cobPerk1);
            listcobPerkX.Add(cobPerk2);
            listcobPerkX.Add(cobPerk3);
            listcobPerkX.Add(cobPerk4);
            listcobPerkX.Add(cobPerk5);

            //Selected Weapon
            string sWeaponName = weaponWebsite.sWeapon;
            DataView dvWeapon = (DataView)cobWeapon.ItemsSource;
            dvWeapon.Sort = "Name";
            cobWeapon.SelectedIndex = dvWeapon.Find(sWeaponName);

            string[] asPerks = new string[5];
            asPerks[0] = weaponWebsite.sPerk1;
            asPerks[1] = weaponWebsite.sPerk2;
            asPerks[2] = weaponWebsite.sPerk3;
            asPerks[3] = weaponWebsite.sPerk4;
            asPerks[4] = weaponWebsite.sPerk5;

            for (int iPerkWeapon = 0; iPerkWeapon < 5; iPerkWeapon++)
            {
                string sPerk = asPerks[iPerkWeapon];
                if (!sPerk.Equals(""))
                {
                    for (int i = 0; i < listPerkCommon.Count; i++)
                    {
                        if (listPerkCommon[i].Name.Equals(sPerk))
                        {
                            listcobLvLX[iPerkWeapon].SelectedColor = Colors.LightGray;
                            listcobPerkX[iPerkWeapon].SelectedIndex = i;
                        }
                    }
                    for (int i = 0; i < listPerkRare.Count; i++)
                    {
                        if (listPerkRare[i].Name.Equals(sPerk))
                        {
                            listcobLvLX[iPerkWeapon].SelectedColor = Colors.DodgerBlue;
                            listcobPerkX[iPerkWeapon].SelectedIndex = i;
                        }
                    }
                    for (int i = 0; i < listPerkLegendary.Count; i++)
                    {
                        if (listPerkLegendary[i].Name.Equals(sPerk))
                        {
                            listcobLvLX[iPerkWeapon].SelectedColor = Colors.DarkOrange;
                            listcobPerkX[iPerkWeapon].SelectedIndex = i;
                        }
                    } 
                }
                else
                {
                    listcobLvLX[iPerkWeapon].SelectedColor = Colors.LightGray;
                    listcobPerkX[iPerkWeapon].SelectedIndex = 0;
                }
            }
        }

        private void dgvInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectWeaponAndPerks();
        }

        private void butLoad_Click(object sender, RoutedEventArgs e)
        {
            string sEpicName = txtPlayer.Text;
            LoadDataFromWebsite(sEpicName);
        }

        private void ValueText_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)e.OriginalSource;
            tb.Dispatcher.BeginInvoke(
                new Action(delegate
                {
                    tb.SelectAll();
                }), System.Windows.Threading.DispatcherPriority.Input);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[] iPerkSelected = new int[5];
            iPerkSelected[0] = cobPerk1.SelectedIndex;
            iPerkSelected[1] = cobPerk2.SelectedIndex;
            iPerkSelected[2] = cobPerk3.SelectedIndex;
            iPerkSelected[3] = cobPerk4.SelectedIndex;
            iPerkSelected[4] = cobPerk5.SelectedIndex;

            PerkQuality[] pQuakity = new PerkQuality[5];
            pQuakity[0] = cobLvL1.SelectedPerkQuality;
            pQuakity[1] = cobLvL2.SelectedPerkQuality;
            pQuakity[2] = cobLvL3.SelectedPerkQuality;
            pQuakity[3] = cobLvL4.SelectedPerkQuality;
            pQuakity[4] = cobLvL5.SelectedPerkQuality;


            BisPerks bis = new BisPerks(DPS.Weapon1);
            bis.CalcBestDPS(DPS.Weapon1, iPerkSelected, pQuakity);
        }
    }
}