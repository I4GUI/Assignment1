using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace The_Debt_Book.Models
{
    public class Person : BindableBase
    {
        private string name;
        private double amount;
        private ObservableCollection<Transaction> transactions;

        public Person()
        {
            transactions = new ObservableCollection<Transaction>();
        }

        public Person Clone()
        {
            return MemberwiseClone() as Person;
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        public ObservableCollection<Transaction> Transactions
        {
            get => transactions;
            set => SetProperty(ref transactions, value);
        }

        public void AddTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
            Amount += transaction.Amount;
        }

        public void RemoveTransaction(Transaction transaction)
        {
            transactions.Remove(transaction);
            Amount -= transaction.Amount;
        }

        public bool IsValid
        {
            get
            {
                //if amount is not a number - return false
                if (Double.IsNaN(Amount))
                    return false;
                //if name is null or white space - return false
                if (string.IsNullOrWhiteSpace(Name))
                    return false;
                //else return true
                return true;
            }
        }
    }

}
