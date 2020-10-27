using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace DebtBook.Models
{
    [Serializable]
    public class DebtorCreditor : BindableBase
    {
        private string name;
        private double totalDebit;
        private ObservableCollection<DebitEntry> debit;

        public DebtorCreditor(string name, ObservableCollection<DebitEntry> debit)
        {
            this.name = name;
            this.debit = debit;
        }

        public DebtorCreditor() {}



        public ObservableCollection<DebitEntry> DebitEntries
        {
            get =>  debit; 
            set => SetProperty(ref debit, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public double TotalDebit
        {
            get => calculateTotalDebit();
            set => SetProperty(ref totalDebit, value);
        }

        private double calculateTotalDebit()
        {
            double sum = 0;
            foreach (DebitEntry d in debit)
            {
                sum += d.Value;
            }
            return sum;
        }

    }


}
