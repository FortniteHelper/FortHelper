using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Media;

namespace FortHelper
{
    /// <summary>
    /// Interaction logic for PerkLvlPicker.xaml
    /// </summary>
    public partial class PerkLvlPicker : UserControl
    {
        #region Dependency properties
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set
            {
                SetValue(SelectedColorProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedColorProperty =
            DependencyProperty.Register("SelectedColor", typeof(Color), typeof(PerkLvlPicker),
            new FrameworkPropertyMetadata(OnSelectedColorChanged));

        public PerkQuality SelectedPerkQuality
        {
            get
            {
                return (PerkQuality)GetValue(SelectedPerkQualityProperty);
            }
            set
            {
                SetValue(SelectedPerkQualityProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedPerkQualityProperty =
            DependencyProperty.Register("SelectedPerkQuality", typeof(PerkQuality), typeof(PerkLvlPicker),
            new FrameworkPropertyMetadata(OnSelectedPerkQualityChange));

        public static void OnSelectedPerkQualityChange(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            PerkLvlPicker cp = obj as PerkLvlPicker;
            PerkQuality newPerk = (PerkQuality)args.NewValue;
            cp.SelectedPerkQuality = newPerk;
            //Debug.WriteLine(newPerk.Name);
        }

        private static void OnSelectedColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            PerkLvlPicker cp = obj as PerkLvlPicker;
            Debug.Assert(cp != null);

            Color newColor = (Color)args.NewValue;
            Color oldColor = (Color)args.OldValue;

            if (newColor == oldColor)
                return;

            // When the SelectedColor changes, set the selected value of the combo box
            if (cp.Picker.SelectedValue == null || (Color)cp.Picker.SelectedValue != newColor)
            {
                // Add the color if not found
                if (!cp.Picker.Items.Contains(newColor))
                    cp.Picker.Items.Add(newColor);
            }

            // Also update the brush
            cp.SelectedBrush = new SolidColorBrush(newColor);

            if(newColor == (Color)Colors.LightGray)
            {
                cp.SelectedPerkQuality = PerkQuality.Common;
            }
            else if (newColor == (Color)Colors.DodgerBlue)
            {
                cp.SelectedPerkQuality = PerkQuality.Rare;
            }
            else if (newColor == (Color)Colors.DarkOrange)
            {
                cp.SelectedPerkQuality = PerkQuality.Legendary;
            }

            cp.OnColorChanged(oldColor, newColor);
        }

        public Brush SelectedBrush
        {
            get { return (Brush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush", typeof(Brush), typeof(PerkLvlPicker),
            new FrameworkPropertyMetadata(OnSelectedBrushChanged));

        private static void OnSelectedBrushChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            PerkLvlPicker cp = (PerkLvlPicker)obj;
            SolidColorBrush newBrush = (SolidColorBrush)args.NewValue;

            if (cp.SelectedColor != newBrush.Color)
                cp.SelectedColor = newBrush.Color;
        }
        #endregion

        #region Events
        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(PerkLvlPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        protected virtual void OnColorChanged(Color oldValue, Color newValue)
        {
            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(oldValue, newValue);
            args.RoutedEvent = PerkLvlPicker.ColorChangedEvent;
            RaiseEvent(args);
        }
        #endregion

        public PerkLvlPicker()
        {
            InitializeComponent();
            InitializeColors();
        }

        public void InitializeColors()
        {
            Picker.Items.Clear();

            // Add some common colors
            AddColor(Colors.LightGray);
            AddColor(Colors.DodgerBlue);
            AddColor(Colors.DarkOrange);
            //AddColor(Color.FromRgb(0, 0, 0));
        }

        private void AddColor(Color c)
        {
            Picker.Items.Add(c);
        }

        /// <summary>
        /// Convert from HSV to Color
        /// http://en.wikipedia.org/wiki/HSL_color_space
        /// </summary>
        /// <param name="h">Hue</param>
        /// <param name="s">Saturation</param>
        /// <param name="v">Value</param>
        /// <returns></returns>
        public static Color HsvToColor(double hue, double sat, double val)
        {
            int i;
            double aa, bb, cc, f;
            double r, g, b;
            r = g = b = 0;

            if (sat == 0) // Gray scale
                r = g = b = val;
            else
            {
                if (hue == 1.0) hue = 0;
                hue *= 6.0;
                i = (int)Math.Floor(hue);
                f = hue - i;
                aa = val * (1 - sat);
                bb = val * (1 - (sat * f));
                cc = val * (1 - (sat * (1 - f)));
                switch (i)
                {
                    case 0: r = val; g = cc; b = aa; break;
                    case 1: r = bb; g = val; b = aa; break;
                    case 2: r = aa; g = val; b = cc; break;
                    case 3: r = aa; g = bb; b = val; break;
                    case 4: r = cc; g = aa; b = val; break;
                    case 5: r = val; g = aa; b = bb; break;
                }
            }
            return Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

    }

    [ValueConversion(typeof(Color), typeof(Brush))]
    public class ColorToBrushConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Brush)) return null;
            if (!(value is Color)) return null;
            SolidColorBrush scb = new SolidColorBrush((Color)value);
            return scb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
