using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CwConverter.Annotations;

namespace CwConverter.ViewModels
{
    internal class InterfaceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool MoneyActive;

        public bool CrystalsActive;

        public bool StepsActive;

        public InterfaceViewModel()
        {
            MoneyValue = 1;
            CrystalValue = 0.03226;
            StepValue = 0.00001;

            MoneyActive = false;
            CrystalsActive = false;
            StepsActive= false;
        }

        #region Properties

        private double _moneyValue;
        public double MoneyValue
        {
            get => _moneyValue;
            set
            {
                _moneyValue = value;
                OnPropertyChanged(nameof(MoneyValue));
            }
        }

        private double _crystalValue;
        public double CrystalValue
        {
            get => _crystalValue;
            set
            {
                _crystalValue = value;
                OnPropertyChanged(nameof(CrystalValue));
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
                ConvertCommodity(nameof(Money), Money);
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
                ConvertCommodity(nameof(Crystals), Crystals);
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
                ConvertCommodity(nameof(Steps), Steps);
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

                    crystals = CrystalValue * value;
                    steps = StepValue * value;
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    break;

                case nameof(Crystals):
                    money = CrystalValue * value / CrystalValue;
                    steps = value / StepValue;
                    values.Add(nameof(Money), money);
                    values.Add(nameof(Steps), steps);
                    break;

                case nameof(Steps):
                    money = MoneyValue * value;
                    crystals = CrystalValue * value;
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
                        Money = value;
                        break;

                    case nameof(Crystals):
                        Crystals = value;
                        break;

                    case nameof(Steps):
                        Steps = value;
                        break;
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
