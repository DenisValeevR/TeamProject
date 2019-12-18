using System;
using System.Collections.Generic;

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
        static void Main(string[] args)
        {
            List<User> Users = new List<User>()
            {new User("Sam", "Yosem", 18, "login", "pass12345"),
            new User("Bugs", "Bunny", 15, "login1", "qwerty")};
            Console.WriteLine();


            Console.WriteLine("Введите цифру соответствующую нужной функции '\t' Нажмите 1 для регистрации '\t' Нажмите 2 для входа");
            string Function = Console.ReadLine();
            switch (Function)
            {
                case ("1")://регистрация
                    Console.WriteLine("Введите логин");
                    string Log=Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string Pass=Console.ReadLine();
                    break;
                case ("2")://вход
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
            foreach (User u in Users)
            {
                Console.WriteLine(u._name);
            }

        }
    }
}
