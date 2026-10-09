using ArendaNedvizhimost.App;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArendaNedvizhimost
{
    public class ContractManager
    {
        private List<Contract> contracts = new List<Contract>();
        private int nextId = 1;
        private PropertyRegistry propertyRegistry;

        public ContractManager(PropertyRegistry propertyRegistry)
        {
            this.propertyRegistry = propertyRegistry;
        }

        public void CreateContract()
        {
            Console.WriteLine("\n--- Создание договора аренды ---");

            // Показать доступные объекты
            propertyRegistry.ViewProperties();

            Console.Write("\nВведите ID объекта недвижимости: ");
            if (!int.TryParse(Console.ReadLine(), out int propertyId))
            {
                Console.WriteLine("Некорректный ID объекта.");
                Console.ReadKey();
                return;
            }

            Console.Write("Название арендатора: ");
            string tenantName = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(tenantName))
            {
                Console.WriteLine("Название арендатора не может быть пустым!");
                Console.ReadKey();
                return;
            }

            Console.Write("Дата начала договора (дд.мм.гггг): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                Console.WriteLine("✗ Некорректная дата.");
                Console.ReadKey();
                return;
            }

            Console.Write("Дата окончания договора (дд.мм.гггг): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                Console.WriteLine("Некорректная дата.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ежемесячная аренда (руб.): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal monthlyRent))
            {
                Console.WriteLine("Некорректная сумма.");
                Console.ReadKey();
                return;
            }

            Contract contract = new Contract(nextId++, propertyId, tenantName, startDate, endDate, monthlyRent);
            contracts.Add(contract);

            Console.WriteLine("\nДоговор успешно создан!");
            Console.ReadKey();
        }

        public void ViewContracts()
        {
            Console.WriteLine("\n--- Договоры аренды ---");

            if (contracts.Count == 0)
            {
                Console.WriteLine("Договоры отсутствуют.");
            }
            else
            {
                foreach (var contract in contracts)
                {
                    Console.WriteLine(contract);
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void TerminateContract()
        {
            Console.WriteLine("\n--- Расторжение договора ---");

            if (contracts.Count == 0)
            {
                Console.WriteLine("Договоры отсутствуют.");
                Console.ReadKey();
                return;
            }

            ViewContracts();

            Console.Write("\nВведите ID договора для расторжения: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contract = contracts.FirstOrDefault(c => c.Id == id);
                if (contract != null)
                {
                    contract.Status = "Расторгнут";
                    Console.WriteLine($"\nДоговор ID {id} расторгнут.");
                }
                else
                {
                    Console.WriteLine("\nДоговор с таким ID не найден.");
                }
            }
            else
            {
                Console.WriteLine("\nНекорректный ID.");
            }

            Console.ReadKey();
        }

        public void ProlongContract()
        {
            Console.WriteLine("\n--- Пролонгация договора ---");

            if (contracts.Count == 0)
            {
                Console.WriteLine("Договоры отсутствуют.");
                Console.ReadKey();
                return;
            }

            ViewContracts();

            Console.Write("\nВведите ID договора для пролонгации: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contract = contracts.FirstOrDefault(c => c.Id == id);
                if (contract != null)
                {
                    Console.Write("Новая дата окончания (дд.мм.гггг): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newEndDate))
                    {
                        contract.EndDate = newEndDate;
                        Console.WriteLine($"\nДоговор ID {id} пролонгирован до {newEndDate:dd.MM.yyyy}.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректная дата.");
                    }
                }
                else
                {
                    Console.WriteLine("\nДоговор с таким ID не найден.");
                }
            }
            else
            {
                Console.WriteLine("\nНекорректный ID.");
            }

            Console.ReadKey();
        }
    }
}