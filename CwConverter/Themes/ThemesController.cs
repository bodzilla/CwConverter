using System;
using System.Windows;

namespace CwConverter.Themes
{
    public static class ThemesController
    {
        public enum ThemeTypes
        {
            Light, ColourfulLight,
            Dark, ColourfulDark
        }

        public static ThemeTypes CurrentTheme { get; set; }

        private static ResourceDictionary ThemeDictionary
        {
            set => Application.Current.Resources.MergedDictionaries[0] = value;
        }

        private static void ChangeTheme(Uri uri) => ThemeDictionary = new ResourceDictionary() { Source = uri };

        public static void SetTheme(ThemeTypes theme)
        {
            string themeName = null;
            CurrentTheme = theme;

            themeName = theme switch
            {
                ThemeTypes.Dark => "DarkTheme",
                ThemeTypes.Light => "LightTheme",
                ThemeTypes.ColourfulDark => "ColourfulDarkTheme",
                ThemeTypes.ColourfulLight => "ColourfulLightTheme",
                _ => null
            };

            try
            {
                if (!string.IsNullOrEmpty(themeName)) ChangeTheme(new Uri($"Themes/{themeName}.xaml", UriKind.Relative));
            }
            catch { }
        }
    }
}
