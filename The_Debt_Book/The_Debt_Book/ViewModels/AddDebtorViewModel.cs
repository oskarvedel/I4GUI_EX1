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
        public AddDebtorViewModel (Debtor newDebtor)
        {
	        CurrentDebtor = newDebtor;
        }

        #region properties
        Debtor currentDebtor;

        public Debtor CurrentDebtor
		{
        get { return currentDebtor; }
        set
        {
	        SetProperty(ref currentDebtor, value);
        }
        }

        #endregion

        #region commands
        ICommand _saveBtnCommand;
        public ICommand SaveBtnCommand
        {
	        get
            {
                return _saveBtnCommand ?? (_saveBtnCommand = new DelegateCommand(

                               SaveBtnCommandExecute, SaveBtnCommandCanExecute)
                           .ObservesProperty(() => CurrentDebtor.Debtorname)
                           .ObservesProperty(() => CurrentDebtor.InitDebt));
            }
        }

        public void SaveBtnCommandExecute()
        {

        }


        public bool SaveBtnCommandCanExecute()
        {
            return IsValid;
        }


        public bool IsValid
        {
            get { return true; }
        }
        #endregion
    }
}

