using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Task_Killer
{
    public class User
    {
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
		public string Login { get; set; }
		public string Pass { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<Task> Tasks { get; set; } = new List<Task>();
		public User(string name, string surname, int age, string login, string pass) 
		{
			Name=name;
			Surname=surname;
			Age=age;
			Login=login;
			Pass=pass;
		}

       
    }
}
