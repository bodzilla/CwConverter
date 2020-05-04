using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CwConverter.Annotations;

namespace CwConverter.ViewModels
{
    internal class InterfaceViewModel : INotifyPropertyChanged
    {
        public InterfaceViewModel()
        {
            CrystalBase = 25;
            StepBase = 90000;
        }

        #region Properties

        private double _crystalBase;
        public double CrystalBase
        {
            get => _crystalBase;
            set
            {
                _crystalBase = value;
                OnPropertyChanged(nameof(CrystalBase));
                ConvertCommodity(nameof(Money), Money);
            }
        }

        private double _stepBase;
        public double StepBase
        {
            get => _stepBase;
            set
            {
                _stepBase = value;
                OnPropertyChanged(nameof(StepBase));
                ConvertCommodity(nameof(Money), Money);
            }
        }

        private double _money;
        public double Money
        {
            get => _money;
            set
            {
                _money = value;
                OnPropertyChanged(nameof(Money));
                if (IsMoneyFocused && !IsCrystalsFocused && !IsStepsFocused) ConvertCommodity(nameof(Money), Money);
            }
        }

        private double _crystals;
        public double Crystals
        {
            get => _crystals;
            set
            {
                _crystals = value;
                OnPropertyChanged(nameof(Crystals));
                if (IsCrystalsFocused && !IsMoneyFocused && !IsStepsFocused) ConvertCommodity(nameof(Crystals), Crystals);
            }
        }

        private double _steps;
        public double Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                OnPropertyChanged(nameof(Steps));
                if (IsStepsFocused && !IsMoneyFocused && !IsCrystalsFocused) ConvertCommodity(nameof(Steps), Steps);
            }
        }

        private bool _isMoneyFocused;
        public bool IsMoneyFocused
        {
            get => _isMoneyFocused;
            set
            {
                _isMoneyFocused = value;
                OnPropertyChanged(nameof(IsMoneyFocused));
            }
        }

        private bool _isCrystalsFocused;
        public bool IsCrystalsFocused
        {
            get => _isCrystalsFocused;
            set
            {
                _isCrystalsFocused = value;
                OnPropertyChanged(nameof(IsCrystalsFocused));
            }
        }

        private bool _isStepsFocused;
        public bool IsStepsFocused
        {
            get => _isStepsFocused;
            set
            {
                _isStepsFocused = value;
                OnPropertyChanged(nameof(IsStepsFocused));
            }
        }

        #endregion

        private void ConvertCommodity(string commodity, double value)
        {
            Dictionary<string, double> values;
            switch (commodity)
            {
                case nameof(Money):
                    values = Convert(nameof(Money), value);
                    Display(values);
                    break;

                case nameof(Crystals):
                    values = Convert(nameof(Crystals), value);
                    Display(values);
                    break;

                case nameof(Steps):
                    values = Convert(nameof(Steps), value);
                    Display(values);
                    break;
            }
        }

        private Dictionary<string, double> Convert(string commodity, double value)
        {
            var values = new Dictionary<string, double>();
            double money;
            double crystals;
            double steps;
            switch (commodity)
            {
                case nameof(Money):

                    crystals = 1 / CrystalBase * value;
                    steps = 1 / StepBase * value;
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    break;

                case nameof(Crystals):
                    money = CrystalBase / 1 * value;
                    steps = money / StepBase;
                    values.Add(nameof(Money), money);
                    values.Add(nameof(Steps), steps);
                    break;

                case nameof(Steps):
                    money = value / 1 * StepBase;
                    crystals = money / CrystalBase;
                    values.Add(nameof(Money), money);
                    values.Add(nameof(Crystals), crystals);
                    break;
            }
            return values;
        }

        private void Display(IReadOnlyDictionary<string, double> values)
        {
            foreach (var (key, value) in values)
            {
                switch (key)
                {
                    case nameof(Money):
                        Money = Math.Round(value);
                        break;

                    case nameof(Crystals):
                        Crystals = Math.Round(value);
                        break;

                    case nameof(Steps):
                        Steps = Math.Round(value);
                        break;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
