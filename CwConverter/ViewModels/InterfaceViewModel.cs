using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CwConverter.Annotations;

namespace CwConverter.ViewModels
{
    internal class InterfaceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public InterfaceViewModel()
        {
            CrystalValue = 31;
            StepValue = 130000;
        }

        #region Properties

        private double _crystalValue;
        public double CrystalValue
        {
            get => _crystalValue;
            set
            {
                _crystalValue = value;
                OnPropertyChanged(nameof(CrystalValue));
                ConvertCommodity(nameof(Money), Money);
            }
        }

        private double _stepValue;
        public double StepValue
        {
            get => _stepValue;
            set
            {
                _stepValue = value;
                OnPropertyChanged(nameof(StepValue));
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
                if (Money > 0) ConvertCommodity(nameof(Money), Money);
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
                //if (Crystals > 0) ConvertCommodity(nameof(Crystals), Crystals);
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
                //if (Steps > 0) ConvertCommodity(nameof(Steps), Steps);
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

                    crystals = 1 / CrystalValue * value;
                    steps = 1 / StepValue * value;
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    break;

                case nameof(Crystals):
                    money = value * CrystalValue / 1;
                    steps = money / StepValue;
                    values.Add(nameof(Money), money);
                    values.Add(nameof(Steps), steps);
                    break;

                case nameof(Steps):
                    money = value / 1 * StepValue;
                    crystals = money / CrystalValue;
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
