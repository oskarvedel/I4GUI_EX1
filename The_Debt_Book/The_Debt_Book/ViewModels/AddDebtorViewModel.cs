﻿using System;
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
    class AddDebtorViewModel : BindableBase
    {
        public AddDebtorViewModel()
        {
            
        }



        #region Commands
        ICommand _newCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _newCommand ?? (_newCommand = new DelegateCommand(() =>
                {
                    
                }));
            }
        }


        #endregion
    }
}

