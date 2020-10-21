using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DebtBook.Models;
using DebtBook.Views;
using DebtBook.ViewModels;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<DebtorCreditor> debtors;


        public MainWindowViewModel()
        {
            debtors = new ObservableCollection<DebtorCreditor>();
            debtors.Add(new DebtorCreditor("Magnus", new ObservableCollection<DebitEntry>(){
                new DebitEntry("Bil", -100020, DateTime.Now),
                new DebitEntry("Fisk", -100020, DateTime.Now),
                new DebitEntry("Sko", -100020, DateTime.Now)
            }));
            debtors.Add(new DebtorCreditor("Lars", new ObservableCollection<DebitEntry>() { new DebitEntry("Fisk", 93, DateTime.Now) }));
            debtors.Add(new DebtorCreditor("John", new ObservableCollection<DebitEntry>() { new DebitEntry("Fisk", 93, DateTime.Now) }));
        }


        public ObservableCollection<DebtorCreditor> Debtors
        {
            get { return debtors; }
            set { SetProperty(ref debtors, value); }
        }

        int currentIndex = -1;
        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                SetProperty(ref currentIndex, value);
            }
        }

        private DebtorCreditor currentDebtor = null;

        public DebtorCreditor CurrentDebtor
        {
            get { return currentDebtor; }
            set { SetProperty(ref currentDebtor, value); }
        }
        

        #region Commands

        ICommand _newCommand;
        public ICommand AddNewDebtorCommand
        {
            get
            {
                return _newCommand ?? (_newCommand = new DelegateCommand(() =>
                {
                    var vm = new AddDebtorCreditorWindowViewModel(Debtors);

                    var dlg = new AddDebtorCreditorWindow()
                    {
                        DataContext = vm,
                        Owner = App.Current.MainWindow
                    };
                    if (dlg.ShowDialog() == true)
                    {
                      
                    }
                },
                () => {
                    return CurrentIndex >= 0;

                }
                ).ObservesProperty(() => CurrentIndex));
            }
        }

        private ICommand _inspectCommand;

        public ICommand InspectCommand
        {
            get
            {
                return _inspectCommand ?? (_inspectCommand = new DelegateCommand( () =>
                {
                    var vm = new InspectDebtorCreditorViewModel(CurrentDebtor);
                    
                    var dlg = new InspectDebtorCreditorWindow()
                    {
                        DataContext = vm,
                        Owner = App.Current.MainWindow
                    };
                    if (dlg.ShowDialog() == true)
                    {
                        // Copy values back not included here, no cancel button.
                    }

                },
                () => {
                    return CurrentIndex >= 0;

                }
                ).ObservesProperty(() => CurrentIndex));

            }
        }


        #endregion



    }
}
