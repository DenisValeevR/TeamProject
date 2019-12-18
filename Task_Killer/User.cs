using System;
using System.Collections.Generic;

namespace Task_Killer
{
    class User
    {
		public string _name { get; set; }
		public string _surname { get; set; }
		public int _age { get; set; }
		private string _login { get; set; }
		private string _pass { get; set; }
		//private List<Note> _note { get; set; }
		//private List<Task> _task { get; set; }
		//List<Note> note, List<Task> task)
		public User(string name, string surname, int age, string login, string pass) 
		{
			_name=name;
			_surname=surname;
			_age=age;
			_login=login;
			_pass=pass;
			//_note=note;
			//_task=task;
		}
    }
}
