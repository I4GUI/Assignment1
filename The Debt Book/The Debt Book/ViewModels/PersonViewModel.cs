using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using The_Debt_Book.Models;

namespace The_Debt_Book.ViewModels
{
    class PersonViewModel : BindableBase
    {
        private Person person;
        private string amount;

        public PersonViewModel(Person debtor, string amount)
        {
            this.person = debtor;
            this.amount = amount;

            AddTransactionCommand = new DelegateCommand(AddTransactionCommand_Execute)
                .ObservesProperty(() => Amount)
                .ObservesProperty(() => Person);
        }

        public PersonViewModel() : this(new Person(), string.Empty)
        {

        }

        #region Properties

        public ObservableCollection<Transaction> Transactions => Person.Transactions;
        public Person Person
        {
            get => person;
            set => SetProperty(ref person, value);
        }

        public string Name => person.Name;
        public double TotalAmount => person.Amount;

        public string Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        private bool ValidatePerson
        {
            get
            {
                if (Person is null)
                    return false;
                return Person.IsValid;
            }
        }

        private bool ValidateAmount
        {
            get
            {
                try
                {
                    Convert.ToDouble(Amount);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        #endregion

        #region Commands

        public ICommand AddTransactionCommand { get; private set; }

        private void AddTransactionCommand_Execute()
        {
            var transaction = new Transaction
            {
                Amount = Convert.ToDouble(amount),
                Date = DateTime.Now
            };
            Person.AddTransaction(transaction);
            RaisePropertyChanged("TotalAmount");
        }

        private bool AddTransactionCommand_CanExecute()
        {
            return ValidatePerson && ValidateAmount;
        }
        
        private ICommand cancelButtonCommand;

        public ICommand CancelButtonCommand
        {
            get
            {
                return cancelButtonCommand ?? (cancelButtonCommand = new DelegateCommand(
                        CancelButtonCommand_Execute, CancelButtonCommand_CanExecute)
                    .ObservesProperty(() => Person.Name)
                    .ObservesProperty(() => Person.Amount));
            }
        }

        private void CancelButtonCommand_Execute()
        {
            //leave empty
        }

        private bool CancelButtonCommand_CanExecute()
        {
            return ValidatePerson;
        }

        #endregion Commands
    }
}
