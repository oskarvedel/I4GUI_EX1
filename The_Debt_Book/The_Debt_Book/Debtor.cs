using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
        private int totaldebt;
        private ObservableCollection<Debt> debts;
        public Debtor()
        {
        }
        public Debtor(Debt initialDebt,string dname)
        {
            name = dname;
            debts = new ObservableCollection<Debt>();
            Debts.Add(initialDebt);
            totaldebt = initialDebt.Debtvalue;
        }
        public string Debtorname
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public void addDebt(int value)
        {
	        debts.Add(new Debt(value, DateTime.Now));
        }

        public int InitDebt
        {
            get => totaldebt;
            set => SetProperty(ref totaldebt, value);
        }

        public ObservableCollection<Debt> Debts
        {
            get => debts;
            set => SetProperty(ref debts, value);

        }
    }
}
