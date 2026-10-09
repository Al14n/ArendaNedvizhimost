using System;

namespace ArendaNedvizhimost.App
{
    class Program
    {
        static PropertyRegistry propertyRegistry = new PropertyRegistry();
        static ContractManager contractManager = new ContractManager(propertyRegistry);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251); // Windows-1251
                Console.InputEncoding = System.Text.Encoding.GetEncoding(1251);
            }

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== АС 'АрендаНедвижимость' ===");
                Console.WriteLine();
                Console.WriteLine("1. Реестр объектов недвижимости");
                Console.WriteLine("2. Управление договорами аренды");
                Console.WriteLine("3. Начисление и учёт платежей");
                Console.WriteLine("0. Выход");
                Console.WriteLine();
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageProperties();
                        break;
                    case "2":
                        ManageContracts();
                        break;
                    case "3":
                        ManagePayments();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageProperties()
        {
            bool backToMenu = false;
            while (!backToMenu)
            {
                Console.Clear();
                Console.WriteLine("=== Реестр объектов недвижимости ===");
                Console.WriteLine();
                Console.WriteLine("1. Добавить объект");
                Console.WriteLine("2. Просмотреть все объекты");
                Console.WriteLine("3. Удалить объект");
                Console.WriteLine("0. Назад в главное меню");
                Console.WriteLine();
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        propertyRegistry.AddProperty();
                        break;
                    case "2":
                        propertyRegistry.ViewProperties();
                        break;
                    case "3":
                        propertyRegistry.DeleteProperty();
                        break;
                    case "0":
                        backToMenu = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageContracts()
        {
            bool backToMenu = false;
            while (!backToMenu)
            {
                Console.Clear();
                Console.WriteLine("=== Управление договорами аренды ===");
                Console.WriteLine();
                Console.WriteLine("1. Создать договор");
                Console.WriteLine("2. Просмотреть все договоры");
                Console.WriteLine("3. Расторгнуть договор");
                Console.WriteLine("4. Пролонгировать договор");
                Console.WriteLine("0. Назад в главное меню");
                Console.WriteLine();
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        contractManager.CreateContract();
                        break;
                    case "2":
                        contractManager.ViewContracts();
                        break;
                    case "3":
                        contractManager.TerminateContract();
                        break;
                    case "4":
                        contractManager.ProlongContract();
                        break;
                    case "0":
                        backToMenu = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        Console.ReadKey();
                        break;
                }
            }
        }


        static void ManagePayments()
        {
            Console.WriteLine("\n=== Начисление и учёт платежей ===");
            Console.WriteLine("Функция в разработке...");
            Console.ReadKey();
        }
    }
}