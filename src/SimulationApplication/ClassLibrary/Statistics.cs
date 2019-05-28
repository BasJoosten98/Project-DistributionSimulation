using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	public abstract class Statistics
	{
        private static int idCounter = 0;
        private int id;
        private int time;

        public int ID { get { return this.id; } }
        public int Time { get { return this.time; } }

        public Statistics(int timeStamp)
        {
            id = idCounter;
            time = timeStamp;
            idCounter++;
        }
	}
}
