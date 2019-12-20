using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Task_Killer
{
    public class Program
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

        public const string _folderPath = "../../../../Data";
        public const string _jsonPathUsers = "dataUser.json";
        public readonly List<User> Users = new List<User>();

        public void SaveDataJSON()
        {
            if (!Directory.Exists(_folderPath))
                Directory.CreateDirectory(_folderPath);
            var serializedUsers = JsonConvert.SerializeObject(Users);
            using (var swAPS = new StreamWriter(Path.Combine(_folderPath, _jsonPathUsers)))
            {
                swAPS.Write(serializedUsers);
            }
        }

        public void RestoreDataJSON()
        {
            using (var sr = new StreamReader(Path.Combine(_folderPath, _jsonPathUsers)))
            {
                var datauser = sr.ReadToEnd();
                var deserealizedusers = JsonConvert.DeserializeObject<List<User>>(datauser);
                Users.AddRange(deserealizedusers);
            }
        }

        public static void AvailableNotes()
        {
            string[] allfiles = Directory.GetFiles("Macintosh HD/Users/DenisValeev/Documents/Programming/Task_Killer/Notes", ".txt", SearchOption.AllDirectories);
            foreach (string filename in allfiles)
            {
                Console.WriteLine(filename);
            }
        }

        public static void CreateNote()
        {
            Console.WriteLine("Введите название заметки которую вы хотите открыть или название новой");
            string note_name = Console.ReadLine();
            Console.WriteLine("Заметка");
            string note_text = Console.ReadLine();
            string way = "" + note_name + ".txt"; // Users\DenisValeev\Documents\Programming\Task_Killer\Notes\
            File.WriteAllText(way, note_name + "\n" + note_text);
        }

        public static void DeleteNote()
        {
            Console.WriteLine("Введите название заметки для удаления");
            string delete_note_name = Console.ReadLine();
            string delete_way = "DenisValeev/Documents/Programming/Task_Killer/Notes/" + delete_note_name + ".txt";
            File.Delete(delete_way);
        }

        public static void Main(string[] args)
        {
            //Users.Add(new User("Sam", "Yosem", 18, "login", "pass12345"));
            //Users.Add(new User("Bugs", "YourBunnyWrote", 15, "login1", "qwerty"));
            //SaveDataJSON(Users);

            Console.WriteLine("Введите цифру соответствующую нужной функции \n Нажмите 1 для входа \n Нажмите 2 для регистрации");
            string Function = Console.ReadLine();
            switch (Function)
            {
                case ("1")://вход
                    Console.WriteLine("Введите логин");
                    string Log = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string Pass = Console.ReadLine();
                    break;
                case ("2")://регистрация
                    Console.WriteLine("Введите имя и фамилию и возраст");
                    string st = Console.ReadLine();//Использовать кортеж или список
                    Console.WriteLine("Введите логин и пароль");
                    string st1 = Console.ReadLine();
                    //Users.Add(new User(st.Split()[0], st.Split()[1], int.Parse(st.Split()[2]), st1.Split()[0], st1.Split()[1]));
                    break;
                default:
                    Console.WriteLine("Команда введена не правильно");
                    break;
            }
            do
            {
                Console.WriteLine("Для создания, просмотра или редактированиея заметки нажмите 1 \nНажмите 2 для создания задачи на день \nДля удаления заметки нажмите 3");
                string Function1 = Console.ReadLine();
                switch (Function1)
                {
                    case ("1"):
                        CreateNote();
                        break;
                    case ("2"):

                        break;
                    case ("3"):
                        Console.WriteLine("Доступные заметки");
                        string[] allfiles = Directory.GetFiles("Macintosh HD/Users/DenisValeev/Documents/Programming/Task_Killer/Notes", ".txt", SearchOption.AllDirectories);
                        foreach (string filename in allfiles)
                        {
                            Console.WriteLine(filename);
                        }
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
