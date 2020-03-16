using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace The_Debt_Book.ViewModels
{
    public class debtsViewModel : BindableBase
    {
        private Debtor _currentDebtor;
        private int inputfield;

        public debtsViewModel(Debtor tempDebtor)
        {
            CurrentDebtor = tempDebtor;
            inputfield = 0;
        }

        #region properties

        public Debtor CurrentDebtor
        {
            get => _currentDebtor;
            set => SetProperty(ref _currentDebtor, value);

        }

        public int Inputfield
        {
            get => inputfield;
            set => SetProperty(ref inputfield, value);
        }

        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(Inputfield.ToString()))
                    isValid = false;

                return isValid;
            }
        }

        #endregion


        #region Commands

        private ICommand addValueBtn;

        public ICommand AddValueBtnCommand
        {
            get => addValueBtn ?? (addValueBtn = new DelegateCommand(

                           AddValueBtnCommandExecute, AddValueBtnCommandCanExecute)
                       .ObservesProperty(() => CurrentDebtor.Debtorname)
                       .ObservesProperty(() => CurrentDebtor.InitDebt));

        }

        public void AddValueBtnCommandExecute()
        {

            if (Inputfield != 0)
            {
                CurrentDebtor.Debts.Add(new Debt(Inputfield,DateTime.Now));
                CurrentDebtor.InitDebt += Inputfield;
            }
        }

        public bool AddValueBtnCommandCanExecute()
        {
            return IsValid;
        }


        #endregion

    }
}

