using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Debt_Book
{
	class Debt
	{
		private int value;
		private DateTime date;

		public Debt(int dvalue, DateTime ddate)
		{
			value = dvalue;
			date = ddate;
		}
		public int Debtvalue
		{
			get { return value; }
			set { value = value; }
		}
		public DateTime datevalue
		{
			get { return date; }

			set { date = value; }
		}
	}
}
