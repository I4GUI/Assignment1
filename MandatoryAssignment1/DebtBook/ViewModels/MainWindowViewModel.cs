﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DebtBook.Models;
using DebtBook.Views;
using DebtBook.ViewModels;
using System.Windows;
using System.Windows.Data;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<DebtorCreditor> debtors;
        private string filePath = "";


        public MainWindowViewModel()
        {
            debtors = new ObservableCollection<DebtorCreditor>();
            debtors.Add(new DebtorCreditor("Magnus", new ObservableCollection<DebitEntry>(){
                new DebitEntry("Bil", -100020, DateTime.Now),
                new DebitEntry("Sko", -100020, DateTime.Now)
            }));
            debtors.Add(new DebtorCreditor("Lars", new ObservableCollection<DebitEntry>() { new DebitEntry("Fisk", 93, DateTime.Now) }));
            debtors.Add(new DebtorCreditor("John", new ObservableCollection<DebitEntry>() { new DebitEntry("Fisk", 93, DateTime.Now) }));
        }


        public ObservableCollection<DebtorCreditor> Debtors
        {
            get => debtors;
            set => SetProperty(ref debtors, value);
        }

        int currentIndex = -1;
        public int CurrentIndex
        {
            get => currentIndex;
            set => SetProperty(ref currentIndex, value);
        }

        private DebtorCreditor currentDebtor = null;

        public DebtorCreditor CurrentDebtor
        {
            get => currentDebtor;
            set => SetProperty(ref currentDebtor, value);
        }

        private string filename = "";

        public string Filename
        {
            get { return filename; }
            set
            {
                SetProperty(ref filename, value);
                RaisePropertyChanged("Title");
            }
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

        #region Save File Menu Commands


        ICommand _closeAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                return _closeAppCommand ?? (_closeAppCommand = new DelegateCommand(() =>
                {
                    Application.Current.MainWindow.Close();
                }));
            }
        }

        ICommand _SaveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand<string>(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute(string argFilename)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Debt book documents|*.dbt|All Files|*.*",
                DefaultExt = "dbt"
            };
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                Filename = Path.GetFileName(filePath);
                SaveFile();
            }
        }

        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute)
                  .ObservesProperty(() => Debtors.Count));
            }
        }

        private void SaveFileCommand_Execute()
        {
            SaveFile();
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (filename != "") && (Debtors.Count > 0);
        }

        private void SaveFile()
        {
            try
            {
                Repository.SaveFile(filePath, Debtors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        ICommand _NewFileCommand;
        public ICommand NewFileCommand
        {
            get { return _NewFileCommand ?? (_NewFileCommand = new DelegateCommand(NewFileCommand_Execute)); }
        }

        private void NewFileCommand_Execute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                
                int numOfdebtor = Debtors.Count;
                if (numOfdebtor > 0)
                {
                    for (int i = 0; i < numOfdebtor; i++)
                    {
                        Debtors.Remove(Debtors[0]);
                    }
                }
                Filename = "";
            }
        }


        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand<string>(OpenFileCommand_Execute)); }
        }

        private void OpenFileCommand_Execute(string argFilename)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Debt Book documents|*.dbt|All Files|*.*",
                DefaultExt = "dbt"
            };
            if (filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                filePath = dialog.FileName;
                Filename = Path.GetFileName(filePath);
                try
                {
                    Repository.ReadFile(filePath, out ObservableCollection<DebtorCreditor> tempDebtors);
                    Debtors = tempDebtors;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        #endregion


        #endregion



    }
}
