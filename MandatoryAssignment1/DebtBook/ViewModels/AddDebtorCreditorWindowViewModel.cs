using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Mvvm;
using DebtBook.Models;
using Prism.Commands;

namespace DebtBook.ViewModels
{
    public class AddDebtorCreditorWindowViewModel : BindableBase
    {
        private DebtorCreditor debtor;
        private string name;
        private double debit;

        public AddDebtorCreditorWindowViewModel() : this(new DebtorCreditor(), string.Empty, double.Parse(string.Empty))
        {

        }

        public AddDebtorCreditorWindowViewModel(DebtorCreditor debtor, string name, double debit)
        {
            this.debtor = debtor;
            this.name = name;
            this.debit = debit;
        }


        #region Properties

        public string newName
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public double newDebit
        {
            get => debit;
            set => SetProperty(ref debit, value);
        }


        #endregion Properties 

        #region Commands

        public ICommand _AddButtonCommand;

        public ICommand AddButtonCommand
        {
            get
            {
                return _AddButtonCommand ??
                       (_AddButtonCommand = new DelegateCommand(
                               AddButtonCommand_Execute, AddButtonCommand_CanExecute)
                           .ObservesProperty(() => newName)
                           .ObservesProperty(() => newDebit));
            }
            //set => throw new NotImplementedException();
        }

        private void AddButtonCommand_Execute()
        {
            //do nothing
        }

        private bool AddButtonCommand_CanExecute()
        {
            return true;
        }

        #endregion Commands

    }


}
