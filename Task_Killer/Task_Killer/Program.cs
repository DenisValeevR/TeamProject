﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task_Killer
{
    class Program
    {
        /*static string[] Parser(ref string st)
        {
            if (!String.IsNullOrEmpty(st))
            {
                string[] par = st.Split(" ");
                 //Использовать кортеж на возврат или массив?
            }
            else 
            {
                Console.WriteLine("Не корректно введеное значение");
            }
        }*/

        public static void CreateNote()
		{
			Console.WriteLine("Введите название заметки которую вы хотите открыть или название новой");
			string note_name=Console.ReadLine();
			Console.WriteLine("Заметка");
			string note_text=Console.ReadLine();
            string way = "/Users/DenisValeev/Documents/Programming/Task_Killer/" + note_name + ".txt";
            File.WriteAllText(way, note_name +"\n"+ note_text);
		}

        static void Main(string[] args)
        {
            List<User> Users = new List<User>()
            {new User("Sam", "Yosem", 18, "login", "pass12345"),
            new User("Bugs", "Bunny", 15, "login1", "qwerty")};
            Console.WriteLine();


            Console.WriteLine("Введите цифру соответствующую нужной функции \n Нажмите 1 для входа \n Нажмите 2 для регистрации");
            string Function = Console.ReadLine();
            switch (Function)
            {
                case ("1")://вход
                    Console.WriteLine("Введите логин");
                    string Log=Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string Pass = Console.ReadLine();
                    break;
                case ("2")://регистрация
                    Console.WriteLine("Введите имя и фамилию и возраст");
                    string st = Console.ReadLine();//Использовать кортеж или список
                    Console.WriteLine("Введите логин и пароль");
                    string st1 = Console.ReadLine();
                    Users.Add(new User(st.Split()[0], st.Split()[1], int.Parse(st.Split()[2]), st1.Split()[0], st1.Split()[1]));
                    break;
                default:
                    Console.WriteLine("Команда введена не правильно");
                    break;
            }
            do
            {
                Console.WriteLine("Для создания, просмотра или редактированиея заметки нажмите 1 \nНажмите 2 для создания задачи на день");
                string Function1 = Console.ReadLine();
                switch (Function1)
                {
                    case ("1"):
                        CreateNote();
                        break;
                    case ("2"):
                        
                        break;
                    default:
                        Console.WriteLine("Команда введена не правильно");
                        break;
                }
                Console.Write("Нажмите любую клавишу для повтора или ESC чтобы выйти");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            foreach (User u in Users)
            {
                Console.WriteLine(u._name);
            }

        }
    }
}