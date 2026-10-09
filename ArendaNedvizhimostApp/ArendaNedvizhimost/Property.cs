using System;

namespace ArendaNedvizhimost.App
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public double Area { get; set; }
        public decimal PricePerMonth { get; set; }

        public Property(int id, string name, string type, string address, double area, decimal pricePerMonth)
        {
            Id = id;
            Name = name;
            Type = type;
            Address = address;
            Area = area;
            PricePerMonth = pricePerMonth;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Name} | Тип: {Type} | Адрес: {Address} | Площадь: {Area} кв.м. | Цена: {PricePerMonth} руб./мес.";
        }
    }
}