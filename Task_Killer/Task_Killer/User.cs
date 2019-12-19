using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task_Killer
{
    public class User
    {
		public string name { get; set; }
		public string surname { get; set; }
		public int age { get; set; }
		private string login { get; set; }
		private string pass { get; set; }
		//private List<Note> _note { get; set; }
		//private List<Task> _task { get; set; }
		//List<Note> note, List<Task> task)
		public User(string name, string surname, int age, string login, string pass) 
		{
			this.name=name;
			this.surname=surname;
			this.age=age;
			this.login=login;
			this.pass=pass;
			//_note=note;
			//_task=task;
		}
    }
}
