using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using Prism;
using Prism.Commands;

namespace The_Debt_Book
{
    public class AddDebtorViewModel : BindableBase
    {
        public AddDebtorViewModel(Debtor debtor)
        {

            
        }
        #region properties
        private Debtor debtorToAdd = null;

        #endregion

        #region commands
        ICommand saveDebtor;
        public ICommand saveDebtor
        {
	        get
	        {
		        return saveDebtor ?? (saveDebtor = new DelegateCommand(() =>
		        {
                    input
		        }
		        }));
	        }
        }
        #endregion
    }
}

