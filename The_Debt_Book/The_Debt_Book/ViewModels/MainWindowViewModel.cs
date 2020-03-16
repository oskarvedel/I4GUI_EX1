using The_Debt_Book;
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

namespace The_Debt_Book
{
	public class MainWindowViewModel : BindableBase
	{
		private ObservableCollection<Debtor> debtorList;
		public MainWindowViewModel()
		{
			debtorList = new ObservableCollection<Debtor>
			{

				new Debtor("Finn Noerbygaard", 1000000),
				new Debtor("Anna Davidsen", -350)

			};
		}

		#region properties
		public ObservableCollection<Debtor> DebtorList
		{
			get { return debtorList; } 
			set { SetProperty(ref debtorList, value);
			}
		}

		private Debtor currentDebtor = null;
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
            get
            {
                return addNewDebtorCommand ?? (addNewDebtorCommand = new DelegateCommand(() =>
                {
                    var newDebtor = new Debtor();
                    var vm = new AddDebtorViewModel(newDebtor);
                    var win2 = new AddDebtorsWindow();
                    win2.DataContext = vm;
                    if (win2.ShowDialog() == true)
                    {
                        debtorList.Add(newDebtor);
                        CurrentDebtor = newDebtor;
                        CurrentIndex = 0;
                    }
                }));
            }
        }

        ICommand editDebtsCommand;
        public ICommand EditDebtsCommand
        {
            get { 
                return editDebtsCommand ?? (editDebtsCommand = new DelegateCommand(() =>
                {
                    var newDebtor = new Debtor();
                    var vm = new debtsViewModel();
                    var win2 = new debts();
                    if (win2.ShowDialog() == true)
                    {

                    }
                }));
            }
        }



    }
}
