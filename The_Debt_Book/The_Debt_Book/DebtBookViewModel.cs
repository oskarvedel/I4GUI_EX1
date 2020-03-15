using The_Debt_Book;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace The_Debt_Book
{
	public class MainWindowViewModel : BindableBase 
	{
		private ObservableCollection<Debts> Debt; 
		private ObservableCollection<Debtors> Debtor; 
		public class DebtBookViewModel : BindableBase
    {
        
    }
}
