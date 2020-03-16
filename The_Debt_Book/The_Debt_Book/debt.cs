using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Debt_Book
{
	public class Debt
	{
		private int debtValue;
		private DateTime date;

		public Debt(int dvalue, DateTime ddate)
		{
			debtValue = dvalue;
			date = ddate;
		}
		public int Debtvalue
		{
			get { return debtValue; }
			set { debtValue = value; }
		}
		public DateTime datevalue
		{
			get { return date; }

			set { date = value; }
		}
	}
}
