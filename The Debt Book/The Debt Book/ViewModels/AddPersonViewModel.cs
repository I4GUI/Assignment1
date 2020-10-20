using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using The_Debt_Book.Models;

namespace The_Debt_Book.ViewModels
{
    class AddPersonViewModel : BindableBase
    {
        private readonly Person newPerson;
        private string newAmount;
        private string newName;

        public AddPersonViewModel() : this(new Person(), string.Empty, string.Empty)
        {
        }

        public AddPersonViewModel(Person newPerson, string newName, string newAmount)
        {
            this.newPerson = newPerson;
            this.newName = newName;
            this.newAmount = newAmount;

            this.SaveButtonCommand = new DelegateCommand(SaveButtonCommand_Execute, SaveButtonCommand_CanExecute)
                .ObservesProperty(() => NewName)
                .ObservesProperty(() => NewAmount);
        }

        #region Properties

        public string NewName
        {
            get => newName;
            set => SetProperty(ref newName, value);
        }

        public string NewAmount
        {
            get => newAmount;
            set => SetProperty(ref newAmount, value);
        }

        public bool IsValid
        {
            get
            {
                if (String.IsNullOrWhiteSpace(NewName))
                    return false;
                if (string.IsNullOrWhiteSpace(NewAmount))
                    return false;
                return ValidateAmount;
            }
        }

        private bool ValidateAmount
        {
            get
            {
                try
                {
                    Convert.ToDouble(NewAmount);
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

        public ICommand SaveButtonCommand { get; private set; }

        private void SaveButtonCommand_Execute()
        {
            // Set name on save
            newPerson.Name = NewName;

            // Add first transaction on save
            newPerson.AddTransaction(new Transaction
            {
                Date = DateTime.Now,
                Amount = Convert.ToDouble(NewAmount),
            });
        }

        private bool SaveButtonCommand_CanExecute => IsValid(;


        #endregion
    }
}
