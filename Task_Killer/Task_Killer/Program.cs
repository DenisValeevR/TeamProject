using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
            else 
            {
                Console.WriteLine("Не корректно введеное значение");
            }
        }*/

        public static void CreateTask()
        {   
            using (FileStream fs = new FileStream("/Users/DenisValeev/Documents/Programming/Task_Killer/Tasks.txt", FileMode.OpenOrCreate))
            {
                Console.WriteLine("Текущие задачи");
                using (StreamReader sr = new StreamReader (fs))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                Console.WriteLine("Записать новую задачу? Нажмите enter для новой задачи или любую другую кнопку для отмены");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter sw = new StreamWriter (fs))
                    {
                        Console.WriteLine("Введите задачу");
                        string line = Console.ReadLine();
                        sw.Write(line);
                    }
                }
            }
        }

        public static void AvailableNotes() 
        {
            string[] allfiles = Directory.GetFiles("/Users/DenisValeev/Documents/Programming/Task_Killer/Notes", "*.txt", SearchOption.AllDirectories);
            foreach (string filename in allfiles)
                {
                    Console.WriteLine(filename);
                }
        }

        public static void CreateNote()
		{
			Console.WriteLine("Введите название заметки которую вы хотите открыть или название новой");
			string note_name=Console.ReadLine();
			Console.WriteLine("Заметка");
			string note_text=Console.ReadLine();
            string way = "" + note_name + ".txt"; // Users\DenisValeev\Documents\Programming\Task_Killer\Notes\
            File.WriteAllText(way, note_name +"\n"+ note_text);
		}

        public static void DeleteNote()
        {
            Console.WriteLine("Введите название заметки для удаления");
            string delete_note_name=Console.ReadLine();
            string delete_way = "Users/DenisValeev/Documents/Programming/Task_Killer/Notes/" + delete_note_name + ".txt";
            File.Delete(delete_way);
        }

        static void Main(string[] args)
        {
            List<User> Users = new List<User>()
            {new User("Sam", "Yosemite", 18, "login", "pass12345"),
            new User("Bugs", "Bunny", 15, "login1", "qwerty")};


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
                Console.WriteLine("Для создания, просмотра или редактированиея заметки нажмите 1 \nНажмите 2 для создания или редактирования задачи на день \nДля удаления заметки нажмите 3");
                string Function1 = Console.ReadLine();
                switch (Function1)
                {
                    case ("1"):
                        
                        CreateNote();
                        break;
                    case ("2"):
                        CreateTask();


                        break;
                    case ("3"):
                        Console.WriteLine("Доступные заметки");
                        AvailableNotes();
                        DeleteNote();
                        break;
                    default:
                        Console.WriteLine("Команда введена не правильно");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для повтора или ESC чтобы выйти");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
        

        }
    }
}
