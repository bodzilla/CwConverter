using System;
using System.Windows;

namespace CwConverter.Extensions
{
    internal static class FocusExtension
    {
        public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached("IsFocused", typeof(bool?), typeof(FocusExtension), new FrameworkPropertyMetadata(IsFocusedChanged) { BindsTwoWayByDefault = true });

        public static bool? GetIsFocused(DependencyObject element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            return (bool?)element.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject element, bool? value)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            element.SetValue(IsFocusedProperty, value);
        }

        private static void IsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)d;

            if (e.OldValue == null)
            {
                frameworkElement.GotFocus += FrameworkElement_GotFocus;
                frameworkElement.LostFocus += FrameworkElement_LostFocus;
            }

            if (!frameworkElement.IsVisible) frameworkElement.IsVisibleChanged += fe_IsVisibleChanged;
            if ((bool)e.NewValue) frameworkElement.Focus();
        }

        private static void fe_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;
            if (!frameworkElement.IsVisible || !(bool)((FrameworkElement)sender).GetValue(IsFocusedProperty)) return;
            frameworkElement.IsVisibleChanged -= fe_IsVisibleChanged;
            frameworkElement.Focus();
        }

        private static void FrameworkElement_GotFocus(object sender, RoutedEventArgs e) => ((FrameworkElement)sender).SetValue(IsFocusedProperty, true);

        private static void FrameworkElement_LostFocus(object sender, RoutedEventArgs e) => ((FrameworkElement)sender).SetValue(IsFocusedProperty, false);
    }
}
