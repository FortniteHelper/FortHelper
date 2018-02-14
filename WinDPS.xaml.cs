using System;
using System.Collections.Generic;
using System.Data;
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

            if(mycolor.Equals(Colors.LightGray))
            {
                ShowPerkName(plpUsePicker.Name, PerkQuality.Common);
            }
            else if(mycolor.Equals(Colors.DodgerBlue))
            {
                ShowPerkName(plpUsePicker.Name, PerkQuality.Rare);
            }
            else if(mycolor.Equals(Colors.DarkOrange))
            {
                ShowPerkName(plpUsePicker.Name, PerkQuality.Legendary);
            }
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
    }
}