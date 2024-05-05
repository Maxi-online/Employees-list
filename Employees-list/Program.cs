using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesList
{
    internal class Program
    {
        // Вывод сотрудников на экран
        static void ReadStaff()
        {
            string[] employeesTxt = File.ReadAllLines("Employees.txt");
            Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-10} {4,-10} {5,-15} {6,-20}",
                "ID", "Time Stamp", "Name", "Age", "Height", "Birth Date", "Birth Place");
            foreach (string employeeTxtString in employeesTxt)
            {
                if (!String.IsNullOrWhiteSpace(employeeTxtString))
                {
                    string[] data = employeeTxtString.Split(new string[] { "#" }, StringSplitOptions.None);
                    Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-10} {4,-10} {5,-15} {6,-20}",
                        data[0], data[1], data[2], data[3], data[4], data[5], data[6]);
                }
            }
        }

        // Запись сотрудников
        static void AddStaff()
        {
            using (StreamWriter sw = new StreamWriter("Employees.txt", true, Encoding.Unicode))
            {
                int id = 1;
                string note = String.Empty;
                char addKey = 'д';
                do
                {
                    Console.WriteLine("\nID записи: {0}", id);
                    note += String.Format("{0}#", id);

                    string date = DateTime.Now.ToShortDateString();
                    string time = DateTime.Now.ToShortTimeString();

                    Console.WriteLine("Время записи: {0} {1}", date, time);
                    note += String.Format("{0} {1}#", date, time);

                    Console.Write("Введите Ф.И.О. сотрудника: ");
                    note += String.Format("{0}#", Console.ReadLine());

                    Console.Write("Введите возраст сотрудника: ");
                    note += String.Format("{0}#", Console.ReadLine());

                    Console.Write("Введите рост сотрудника: ");
                    note += String.Format("{0}#", Console.ReadLine());

                    Console.Write("Введите дату рождения сотрудника: ");
                    note += String.Format("{0}#", Console.ReadLine());

                    Console.Write("Введите место рождения сотрудника: ");
                    note += Console.ReadLine();

                    sw.WriteLine(note);

                    Console.Write("\nПродолжить (д/н)? ");
                    addKey = Console.ReadKey(true).KeyChar;
                    id++;
                    note = String.Empty;

                } while (char.ToLower(addKey) == 'д');
            }
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Выберите пункт меню\n 1 - Список сотрудников\n 2 - Новая запись\n");
                String optKey = Console.ReadLine();
                switch (optKey)
                {
                    case "1":
                        Console.Write("\nСписок сотрудников\n");
                        ReadStaff();
                        break;

                    case "2":
                        Console.Write("\nНовая запись");
                        AddStaff();
                        break;
                    default: Console.WriteLine("\nНеверный ввод"); continue;
                }
            }
            while (true);
        }
    }
}
