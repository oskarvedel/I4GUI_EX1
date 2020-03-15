﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace The_Debt_Book
{
    public class Debtor : BindableBase
    {
        private string name;
        private int value;

        public Debtor()
        {
        }

        public Debtor(string dname, int dvalue)
        {
            name = dname;
            value = dvalue;

        }

        public string Debtorname
        {
            get { return name; }

            set { name = value; }
        }

        public int Debtvalue
        {
            get { return value; }

            set { value = value; }
        }
        
    }
}
