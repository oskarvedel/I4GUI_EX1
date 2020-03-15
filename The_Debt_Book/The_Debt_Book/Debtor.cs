using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

namespace The_Debt_Book
{
    public class Debtor
    {
        private string name;
        private int totaldebt;
        private List<Debt> debts;


        public Debtor()
        {
        }
        public Debtor(string dname, int initialValue)
        {
            name = dname;
            totaldebt = initialValue;

            debts = new List<Debt>();
        }
        public string Debtorname
        {
            get { return name; }

            set { name = value; }
        }

        public void addDebt(int value, DateTime date)
        {
	        debts.Add(new Debt(value, date));
        }

    }
}
