using System;
using System.Collections.Generic;

namespace Task_Killer
{
    public class Task
	{
        public DateTime DeadLine { get; set; }
		public string Text{ get; set;}
		public bool IsDone { get; set; }
	}
}