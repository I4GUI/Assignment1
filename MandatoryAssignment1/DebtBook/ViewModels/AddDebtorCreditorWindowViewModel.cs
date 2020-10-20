using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using DebtBook.Models;

namespace DebtBook.ViewModels
{
    public class AddDebtorCreditorWindowViewModel : BindableBase
    {
        private DebtorCreditor debtor;
        private string name;
        private double debit;

        public AddDebtorCreditorWindowViewModel(DebtorCreditor debtor, string name, double debit)
        {
            this.debtor = debtor;
            this.name = name;
            this.debit = debit;
        }



    }

    #region Properties

    #endregion Properties 

    #region Commands

    #endregion Commands
}
