using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees_list
{
    internal class Program
    {
        //Вывод сотрудников на экран
        static void ReadStaff(string note)
        {
            string[] employeesTxt = File.ReadAllLines("Сотрудники.txt");
            foreach (string employeeTxtString in employeesTxt)
            {
                if (!String.IsNullOrWhiteSpace(employeeTxtString))
                {
                    Console.WriteLine($"{"ID"}{" Время записи"}{" Ф.И.О."}{" Возраст"}{" Рост"}{" Дата рождения"}{" Место рождения"}");
                    string[] data = employeeTxtString.Split(new string[] { "#" }, StringSplitOptions.None);
                    Console.WriteLine($"{data[0]} {data[1]} {data[2]} {data[3]} {data[4]} {data[5]} {data[6]}\n");
                }
            }
        }

        //Запись сотрудников
        static void AddStaff(string note)
        {
            using (StreamWriter sw = new StreamWriter("Сотрудники.txt", true, Encoding.Unicode))
            {
                int ID = new int();
                char AddKey = 'д';
                do
                {
                    ID++;
                    Console.WriteLine($"\nID записи {ID}");
                    note += $"\n{ID}#";

                    string date = DateTime.Now.ToShortDateString();
                    string time = DateTime.Now.ToShortTimeString();

                    Console.WriteLine($"Время записи {date} {time}");
                    note += $"{date} {time}#";

                    Console.Write("Введите Ф.И.О. сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите возраст сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите рост сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите дату рождения сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите место рождения сотрудника: ");
                    note += $"{Console.ReadLine()}";
                    sw.Write(note);

                    Console.Write("\nПродолжить н/д\n");
                    AddKey = Console.ReadKey(true).KeyChar;

                } while (char.ToLower(AddKey) == 'д');
            }
        }

        static void Main(string[] args)
        {
            string note = String.Empty;

            do
            {
                Console.Write("Выберите пункт меню\n 1 - Список сотрудников\n 2 - Новая запись\n");
                String OptKey = Console.ReadLine();
                switch (OptKey)
                {
                    case "1":
                        Console.Write("\nСписок сотрудников\n");
                        ReadStaff(note);
                        break;

                    case "2":
                        Console.Write("\nНовая запись");
                        AddStaff(note);
                        break;
                    default: Console.WriteLine("\nНеверный ввод"); continue;
                }
            }
            while (true);
        }
    }
}
