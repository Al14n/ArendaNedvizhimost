using System;
using System.Collections.Generic;
using System.Linq;

namespace ArendaNedvizhimost.App
{
    public class PropertyRegistry
    {
        private List<Property> properties = new List<Property>();
        private int nextId = 1;

        public void AddProperty()
        {
            Console.WriteLine("\n--- Добавление объекта недвижимости ---");

            Console.Write("Название объекта: ");
            string name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Название не может быть пустым!");
                Console.ReadKey();
                return;
            }

            Console.Write("Тип (ТЦ/Офис/Склад): ");
            string type = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(type))
            {
                Console.WriteLine("Тип не может быть пустым!");
                Console.ReadKey();
                return;
            }

            Console.Write("Адрес: ");
            string address = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Адрес не может быть пустым!");
                Console.ReadKey();
                return;
            }

            Console.Write("Площадь (кв.м.): ");
            string areaInput = Console.ReadLine()?.Trim();
            if (!double.TryParse(areaInput, out double area))
            {
                Console.WriteLine("Некорректный формат площади!");
                Console.ReadKey();
                return;
            }

            Console.Write("Цена за месяц (руб.): ");
            string priceInput = Console.ReadLine()?.Trim();
            if (!decimal.TryParse(priceInput, out decimal price))
            {
                Console.WriteLine("Некорректный формат цены!");
                Console.ReadKey();
                return;
            }

            Property property = new Property(nextId++, name, type, address, area, price);
            properties.Add(property);

            Console.WriteLine("\nОбъект успешно добавлен!");
            Console.ReadKey();
        }

        public void ViewProperties()
        {
            Console.WriteLine("\n--- Реестр объектов недвижимости ---");

            if (properties.Count == 0)
            {
                Console.WriteLine("Реестр пуст.");
            }
            else
            {
                foreach (var prop in properties)
                {
                    Console.WriteLine(prop);
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void DeleteProperty()
        {
            Console.WriteLine("\n--- Удаление объекта недвижимости ---");

            if (properties.Count == 0)
            {
                Console.WriteLine("Реестр пуст.");
                Console.ReadKey();
                return;
            }

            ViewProperties();

            Console.Write("\nВведите ID объекта для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var property = properties.FirstOrDefault(p => p.Id == id);
                if (property != null)
                {
                    properties.Remove(property);
                    Console.WriteLine($"\nОбъект '{property.Name}' удален!");
                }
                else
                {
                    Console.WriteLine("\nОбъект с таким ID не найден.");
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