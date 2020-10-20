using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
//using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
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

            this.AddButtonCommand = new DelegateCommand(AddButtonCommandHandler)
                .ObservesProperty(() => newName)
                .ObservesProperty(() => newDebit);
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

        public ICommand AddButtonCommand { get; private set; }

        private void AddButtonCommandHandler()
        {
            
            
        }

        #endregion Commands
    }


}
