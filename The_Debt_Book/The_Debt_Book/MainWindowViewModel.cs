using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace The_Debt_Book
{
	public class MainWindowViewModel
	{
		private ObservableCollection<Debtor> debtorList;
        public MainWindowViewModel() 
		{
			debtorList = new ObservableCollection<Debtor>
			{
#if DEBUG
				new Debtor("Finn Nørbygaard", 1000000),
				new Debtor("Anna Davidsen", -350)
#endif
			};
		}

		#region properties
		public ObservableCollection<Debtor> DebtorList
		{
			get { return debtorList; } 
			set { SetProperty(ref debtorList, value);
		}
		}
#endregion
	}
}
