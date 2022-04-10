using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CwConverter.Annotations;
using Prism.Commands;

namespace CwConverter.ViewModels
{
    internal class InterfaceViewModel : INotifyPropertyChanged
    {
        public InterfaceViewModel() => ResetValues();

        private void ResetValues()
        {
            ItemTextValue = "Item";

            CrystalBase = 37;
            StepBase = 180_000;
            DrugBase = 350_000;
            PotionBase = 180_000;
            DonatorPackBase = 7_000_000_000;
            ItemBase = 100;

            Money = 0;
            Crystals = 0;
            Steps = 0;
            Drugs = 0;
            Potions = 0;
            DonatorPacks = 0;
            Items = 0;
        }

        private DelegateCommand _btnResetValues;
        public DelegateCommand BtnResetValues => _btnResetValues ??= new DelegateCommand(ResetValues, () => true);

        #region Base

        public event PropertyChangedEventHandler PropertyChanged;

        private double _crystalBase;
        public double CrystalBase
        {
            get => _crystalBase;
            set
            {
                _crystalBase = value;
                OnPropertyChanged(nameof(CrystalBase));
                ConvertCommodity(nameof(Crystals), Crystals);
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
                ConvertCommodity(nameof(Steps), Steps);
            }
        }

        private double _drugBase;
        public double DrugBase
        {
            get => _drugBase;
            set
            {
                _drugBase = value;
                OnPropertyChanged(nameof(DrugBase));
                ConvertCommodity(nameof(Drugs), Drugs);
            }
        }

        private double _potionBase;
        public double PotionBase
        {
            get => _potionBase;
            set
            {
                _potionBase = value;
                OnPropertyChanged(nameof(PotionBase));
                ConvertCommodity(nameof(Potions), Potions);
            }
        }

        private double _donatorPackBase;
        public double DonatorPackBase
        {
            get => _donatorPackBase;
            set
            {
                _donatorPackBase = value;
                OnPropertyChanged(nameof(DonatorPackBase));
                ConvertCommodity(nameof(DonatorPacks), DonatorPacks);
            }
        }

        private double _itemBase;
        public double ItemBase
        {
            get => _itemBase;
            set
            {
                _itemBase = value;
                OnPropertyChanged(nameof(ItemBase));
                ConvertCommodity(nameof(Items), Items);
            }
        }

        private string _itemTextValue;
        public string ItemTextValue
        {
            get => _itemTextValue;
            set
            {
                _itemTextValue = value;
                OnPropertyChanged(nameof(ItemTextValue));
                OnPropertyChanged(nameof(ItemsTextValue));
            }
        }

        public string ItemsTextValue => ItemTextValue + "s";

        #endregion

        #region Convertions

        private double _money;
        public double Money
        {
            get => _money;
            set
            {
                _money = value;
                OnPropertyChanged(nameof(Money));
                if (IsMoneyFocused) ConvertCommodity(nameof(Money), Money);
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
                if (IsCrystalsFocused) ConvertCommodity(nameof(Crystals), Crystals);
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
                if (IsStepsFocused) ConvertCommodity(nameof(Steps), Steps);
            }
        }

        private double _drugs;
        public double Drugs
        {
            get => _drugs;
            set
            {
                _drugs = value;
                OnPropertyChanged(nameof(Drugs));
                if (IsDrugsFocused) ConvertCommodity(nameof(Drugs), Drugs);
            }
        }

        private double _potions;
        public double Potions
        {
            get => _potions;
            set
            {
                _potions = value;
                OnPropertyChanged(nameof(Potions));
                if (IsPotionsFocused) ConvertCommodity(nameof(Potions), Potions);
            }
        }

        private double _donatorPacks;
        public double DonatorPacks
        {
            get => _donatorPacks;
            set
            {
                _donatorPacks = value;
                OnPropertyChanged(nameof(DonatorPacks));
                if (IsDonatorPacksFocused) ConvertCommodity(nameof(DonatorPacks), DonatorPacks);
            }
        }

        private double _items;
        public double Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
                if (IsItemsFocused) ConvertCommodity(nameof(Items), Items);
            }
        }

        #endregion

        #region Focused

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

        private bool _isDrugsFocused;
        public bool IsDrugsFocused
        {
            get => _isDrugsFocused;
            set
            {
                _isDrugsFocused = value;
                OnPropertyChanged(nameof(IsDrugsFocused));
            }
        }

        private bool _isPotionsFocused;
        public bool IsPotionsFocused
        {
            get => _isPotionsFocused;
            set
            {
                _isPotionsFocused = value;
                OnPropertyChanged(nameof(IsPotionsFocused));
            }
        }

        private bool _isDonatorPacksFocused;
        public bool IsDonatorPacksFocused
        {
            get => _isDonatorPacksFocused;
            set
            {
                _isDonatorPacksFocused = value;
                OnPropertyChanged(nameof(IsDonatorPacksFocused));
            }
        }

        private bool _isItemsFocused;
        public bool IsItemsFocused
        {
            get => _isItemsFocused;
            set
            {
                _isItemsFocused = value;
                OnPropertyChanged(nameof(IsItemsFocused));
            }
        }

        #endregion

        private void ConvertCommodity(string commodity, double value) => Display(Convert(commodity, value));

        private Dictionary<string, double> Convert(string commodity, double value)
        {
            var values = new Dictionary<string, double>();
            double money;
            double crystals;
            double steps;
            double drugs;
            double potions;
            double donatorPacks;
            double items;

            switch (commodity)
            {
                case nameof(Money):
                    crystals = 1 / CrystalBase * value;
                    steps = 1 / StepBase * value;
                    drugs = 1 / DrugBase * value;
                    potions = 1 / PotionBase * value;
                    donatorPacks = 1 / DonatorPackBase * value;
                    items = 1 / ItemBase * value;

                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    values.Add(nameof(Drugs), drugs);
                    values.Add(nameof(Potions), potions);
                    values.Add(nameof(DonatorPacks), donatorPacks);
                    values.Add(nameof(Items), items);
                    break;

                case nameof(Crystals):
                    money = CrystalBase / 1 * value;
                    steps = money / StepBase;
                    drugs = money / DrugBase;
                    potions = money / PotionBase;
                    donatorPacks = money / DonatorPackBase;
                    items = money / ItemBase;

                    values.Add(nameof(Money), money);
                    values.Add(nameof(Steps), steps);
                    values.Add(nameof(Drugs), drugs);
                    values.Add(nameof(Potions), potions);
                    values.Add(nameof(DonatorPacks), donatorPacks);
                    values.Add(nameof(Items), items);
                    break;

                case nameof(Steps):
                    money = value / 1 * StepBase;
                    crystals = money / CrystalBase;
                    drugs = money / DrugBase;
                    potions = money / PotionBase;
                    donatorPacks = money / DonatorPackBase;
                    items = money / ItemBase;

                    values.Add(nameof(Money), money);
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Drugs), drugs);
                    values.Add(nameof(Potions), potions);
                    values.Add(nameof(DonatorPacks), donatorPacks);
                    values.Add(nameof(Items), items);
                    break;

                case nameof(Drugs):
                    money = value / 1 * DrugBase;
                    crystals = money / CrystalBase;
                    steps = money / StepBase;
                    potions = money / PotionBase;
                    donatorPacks = money / DonatorPackBase;
                    items = money / ItemBase;

                    values.Add(nameof(Money), money);
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    values.Add(nameof(Potions), potions);
                    values.Add(nameof(DonatorPacks), donatorPacks);
                    values.Add(nameof(Items), items);
                    break;

                case nameof(Potions):
                    money = value / 1 * PotionBase;
                    crystals = money / CrystalBase;
                    steps = money / StepBase;
                    drugs = money / DrugBase;
                    donatorPacks = money / DonatorPackBase;
                    items = money / ItemBase;

                    values.Add(nameof(Money), money);
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    values.Add(nameof(Drugs), drugs);
                    values.Add(nameof(DonatorPacks), donatorPacks);
                    values.Add(nameof(Items), items);
                    break;

                case nameof(DonatorPacks):
                    money = value / 1 * DonatorPackBase;
                    crystals = money / CrystalBase;
                    steps = money / StepBase;
                    drugs = money / DrugBase;
                    potions = money / PotionBase;
                    items = money / ItemBase;

                    values.Add(nameof(Money), money);
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    values.Add(nameof(Drugs), drugs);
                    values.Add(nameof(Potions), potions);
                    values.Add(nameof(Items), items);
                    break;

                case nameof(Items):
                    money = value / 1 * ItemBase;
                    crystals = money / CrystalBase;
                    steps = money / StepBase;
                    drugs = money / DrugBase;
                    potions = money / PotionBase;
                    donatorPacks = money / DonatorPackBase;

                    values.Add(nameof(Money), money);
                    values.Add(nameof(Crystals), crystals);
                    values.Add(nameof(Steps), steps);
                    values.Add(nameof(Drugs), drugs);
                    values.Add(nameof(Potions), potions);
                    values.Add(nameof(DonatorPacks), donatorPacks);
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
                        Money = Math.Floor(value);
                        break;

                    case nameof(Crystals):
                        Crystals = Math.Floor(value);
                        break;

                    case nameof(Steps):
                        Steps = Math.Floor(value);
                        break;

                    case nameof(Drugs):
                        Drugs = Math.Floor(value);
                        break;

                    case nameof(Potions):
                        Potions = Math.Floor(value);
                        break;

                    case nameof(DonatorPacks):
                        DonatorPacks = Math.Floor(value);
                        break;

                    case nameof(Items):
                        Items = Math.Floor(value);
                        break;
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
