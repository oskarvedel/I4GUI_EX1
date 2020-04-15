using The_Debt_Book;
using The_Debt_Book.Data;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.Windows.Data;
using Microsoft.Win32;

namespace The_Debt_Book.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
        private Debtor _currentDebtor;
		private ObservableCollection<Debtor> debtorList;
        private string filePath = "";
        public MainWindowViewModel()
        {
            debtorList = new ObservableCollection<Debtor>()
            {
				new Debtor(new Debt(100,DateTime.Now), "Finn"),
                new Debtor(new Debt(1100,DateTime.Now), "Ole")
			};
        }

		#region properties
		public ObservableCollection<Debtor> DebtorList
		{
			get { return debtorList; } 
			set { SetProperty(ref debtorList, value);
			}
		}


		Debtor currentDebtor = null;
        public Debtor CurrentDebtor
		{
			get
			{
				return currentDebtor;
			}
			set { SetProperty(ref currentDebtor, value); }
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

		#endregion

		#region Commands

		#endregion
		ICommand addNewDebtorCommand;
		public ICommand AddNewDebtorCommand
        {
            get => addNewDebtorCommand ?? (addNewDebtorCommand = new DelegateCommand(() =>
            {
                
                    var newDebtor = new Debtor();
                    var vm = new AddDebtorViewModel(newDebtor);
                    var win2 = new AddDebtorsWindow
                    {
                        DataContext = vm
                    };
                    if (win2.ShowDialog() == true)
                    {
                        DebtorList.Add(newDebtor);
                        newDebtor.Debts.Add(new Debt(newDebtor.InitDebt, DateTime.Now));
                        CurrentDebtor = newDebtor;
                        CurrentIndex = (DebtorList.Count - 1);
                    }

            }));
        }

        ICommand editDebtsCommand;
        public ICommand EditDebtsCommand
        { 
            get => editDebtsCommand ?? (editDebtsCommand = new DelegateCommand(() =>
                       { 
                           var tempDebtor = CurrentDebtor.Clone();
                           var vm = new debtsViewModel(tempDebtor);
                           var win2 = new debts()
                           {
                               DataContext = vm
                           };

                           if (win2.ShowDialog() == true)
                           {
                               CurrentDebtor.Debtorname = tempDebtor.Debtorname;
                               CurrentDebtor.InitDebt = tempDebtor.InitDebt;
                           }
                       },
                       () => {
                                 return CurrentIndex >= 0;
                             }
                                ).ObservesProperty(() => CurrentIndex));
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


        ICommand _SaveCommand;

        public ICommand SaveCommand
        {
            get { return _SaveCommand ?? (_SaveCommand = new DelegateCommand<string>(SaveCommand_execute)); }
        }

        private void SaveCommand_execute(string argFilename)
        {
           var dialog = new SaveFileDialog
             {
               Filter = "Debtors|*.txt|All Files|*.*",
               DefaultExt = "txt"
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


        private void SaveFile()
        {
            try
            {
                Repo.SaveFile(filePath, DebtorList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        ICommand _OpenCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenCommand ?? (_OpenCommand = new DelegateCommand<string>(OpenCommand_execute)); }
        }

        private void OpenCommand_execute(string argFilename)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Debtors|*.txt|All Files|*.*",
                DefaultExt = "txt"
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
                    Repo.ReadFile(filePath, out ObservableCollection<Debtor> tempDeptor);
                    DebtorList = tempDeptor;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

}
