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

namespace The_Debt_Book.ViewModels
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

        #region Commands

        private ICommand _saveBtnCommand;
        public ICommand SaveCommand
        {
	        get
            {
                return _saveBtnCommand ?? (_saveBtnCommand = new DelegateCommand(

                               SaveCommandExecute, SaveCommandCanExecute)
                           .ObservesProperty(() => CurrentDebtor.Debtorname)
                           .ObservesProperty(() => CurrentDebtor.InitDebt));
            }
        }
        #endregion
        private void SaveCommandExecute()
        {
        }


        private bool SaveCommandCanExecute()
        {
            return IsValid;
        }


        public bool IsValid
        {

            get
            {
                //bool isValid = true;

                //if (string.IsNullOrWhiteSpace(CurrentDebtor.Debtorname))
                //    isValid = false;

                //if (string.IsNullOrWhiteSpace(CurrentDebtor.InitDebt.ToString()))
                //    isValid = false;

                return true;
            }

        }
    }
}

