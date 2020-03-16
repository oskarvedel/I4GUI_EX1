using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace The_Debt_Book
{
	public class Debt : BindableBase
	{
		private int debtValue;
		private DateTime date;

        public Debt()
		{
			Datevalue = DateTime.Now;
			debtValue = 0;

		}

		public Debt(int dvalue, DateTime ddate)
		{
			debtValue = dvalue;
			date = ddate;
		}


		public int Debtvalue
		{
            get => debtValue;
            set => SetProperty(ref debtValue, value);
		}
		public DateTime Datevalue
		{
            get => date;
            set => SetProperty(ref date, value);
		}
	}
}
