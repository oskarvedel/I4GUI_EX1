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

namespace The_Debt_Book.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private ObservableCollection<Debtor> debtorList;

        public MainWindowViewModel()
        {
            debtorList = new ObservableCollection<Debtor>()
            {
				new Debtor(new Debt(100,DateTime.Now), "Finn")
            };
        }

		#region properties
		public ObservableCollection<Debtor> DebtorList
		{
			get { return debtorList; } 
			set { SetProperty(ref debtorList, value);
			}
		}


		Debtor currentDebtor;
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
					var win2 = new AddDebtorsWindow()
					{
						DataContext = vm
					};
					if (win2.ShowDialog() == true)
                    {
                        debtorList.Add(newDebtor);
						newDebtor.Debts.Add(new Debt(newDebtor.InitDebt,DateTime.Now));
                        CurrentDebtor = newDebtor;
                        CurrentIndex = (debtorList.Count - 1);
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
