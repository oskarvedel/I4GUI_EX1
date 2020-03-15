using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Debt_Book
{
    class Debtors
    {
        private string name;
        private int value;

        public Debtors()
        {
        }

        public Debtors(string dname, int dvalue)
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
