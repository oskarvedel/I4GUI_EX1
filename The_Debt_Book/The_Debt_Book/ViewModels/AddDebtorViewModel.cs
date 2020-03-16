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
        public ICommand _saveBtnCommand
        {
	        return _saveBtnCommand ?? (_saveBtnCommand = new DelegateCommand()
	        .ObservesProperty(() => CurrentDebtor())
	        .ObservesProperty(() => CurrentDebtor.CodeName));
        }

    private void OkButtonCommandExecute()
    { }

    private bool OkButtonCommandCanExecute()
    {
    return IsValid;
    }

    public bool IsValid
    {
    get
    {
	    bool isValid = true;
	    if (string.IsNullOrWhiteSpace(CurrentDebtor.Name))
		    isValid = false;
	    if (string.IsNullOrWhiteSpace(CurrentDebtor.Debt.ToString()))
		    isValid = false;
	    return isValid;
    }
    }
    #endregion
}
}

