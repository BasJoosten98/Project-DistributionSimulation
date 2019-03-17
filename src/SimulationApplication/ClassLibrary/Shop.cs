using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationApplication.ClassLibrary
{
	public class Shop : Building
	{
		int stock;

		public void Restock()
		{
			throw new NotImplementedException();
		}

		public void Sell(int demand)
		{
			throw new NotImplementedException();
		}

		public event EventHandler RestockEvent;

        public Shop() : base()
        {

        }
	}
}
