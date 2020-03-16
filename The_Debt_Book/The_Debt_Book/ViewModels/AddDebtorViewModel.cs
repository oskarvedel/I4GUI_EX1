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
        private Debtor _currentDebtor;

        public Debtor CurrentDebtor
		{
        get  => _currentDebtor;
        set => SetProperty(ref _currentDebtor, value);
        
        }

        public bool IsValid
        {

            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(CurrentDebtor.Debtorname))
                    isValid = false;
                if (string.IsNullOrWhiteSpace(CurrentDebtor.InitDebt.ToString()))
                    isValid = false;
                return isValid;
            }

        }
        #endregion

        #region commands
        ICommand _saveBtnCommand;
        public ICommand SaveBtnCommand
        {
	        get => _saveBtnCommand ?? (_saveBtnCommand = new DelegateCommand(
            

                           SaveBtnCommandExecute, SaveBtnCommandCanExecute)
                       .ObservesProperty(() => CurrentDebtor.Debtorname)
                       .ObservesProperty(() => CurrentDebtor.InitDebt));
            
        }

        public void SaveBtnCommandExecute()
        { }


        public bool SaveBtnCommandCanExecute()
        {
            return IsValid;
        }

        #endregion
    }
}

