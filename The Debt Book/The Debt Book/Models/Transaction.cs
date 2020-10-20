using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace The_Debt_Book.Models
{
    public class Transaction : BindableBase
    {
        private DateTime date;
        private double amount;

        public Transaction Clone()
        {
            return MemberwiseClone() as Transaction;
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
    }
}
