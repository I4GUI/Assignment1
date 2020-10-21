using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Mvvm;
using DebtBook.Models;
using Prism.Commands;

namespace DebtBook.ViewModels
{
    public class AddDebtorCreditorWindowViewModel : BindableBase
    {
        private ObservableCollection<DebtorCreditor> _debtors;

        public AddDebtorCreditorWindowViewModel(ObservableCollection<DebtorCreditor> debtors)
        {
            _debtors = debtors;
        }

        #region Properties

        double val;
        public double Value
        {
            get { return val; }
            set
            {
                SetProperty(ref val, value);
            }
        }

        string name = "";
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }

        string desc = "";
        public string Desc
        {
            get { return desc; }
            set
            {
                SetProperty(ref desc, value);
            }
        }

        #endregion Properties 


        #region Commands

        public ICommand _AddButtonCommand;

        public ICommand AddButtonCommand
        {
            get
            {
                return _AddButtonCommand ?? (_AddButtonCommand = new DelegateCommand(() =>
                {
                    _debtors.Add(new DebtorCreditor(Name, new ObservableCollection<DebitEntry>() { new DebitEntry(Desc, Value, DateTime.Now) }));
                }));
            }
        }

        #endregion Commands

    }


}
