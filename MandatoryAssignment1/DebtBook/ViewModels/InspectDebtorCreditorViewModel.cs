﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class InspectDebtorCreditorViewModel : BindableBase
    {
        
        public InspectDebtorCreditorViewModel(DebtorCreditor debtorToInspect)
        {
            debtorToInspect = new DebtorCreditor("Magnus",
                new ObservableCollection<DebitEntry>()
                {
                    new DebitEntry("Bil", -100020, DateTime.Now),
                    new DebitEntry("Hus", -10, DateTime.Now),
                    new DebitEntry("Vase", -123020, DateTime.Now),
                    new DebitEntry("Sko", 20, DateTime.Now)
                });
            InspectedDebtor = debtorToInspect;
        }


        #region Properties
        private DebtorCreditor inspectedDebtor;

        public DebtorCreditor InspectedDebtor
        {
            get => inspectedDebtor;
            set => SetProperty(ref inspectedDebtor, value);
        }

        #endregion

        #region Commands

        public ICommand _CloseCommand;

        public ICommand CloseCommand
        {
            get
            {
                return _CloseCommand ??
                       (_CloseCommand = new DelegateCommand(
                           CloseCommand_Execute, CloseCommand_CanExecute));
            }
        }

        private void CloseCommand_Execute()
        {
            // Nothing needs to be done here.
        }

        private bool CloseCommand_CanExecute()
        {
            // Add validity check here if needed.
            return true;
        }

        #endregion


    }
}
