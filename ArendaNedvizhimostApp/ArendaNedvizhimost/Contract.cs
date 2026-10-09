using System;

namespace ArendaNedvizhimost
{
    public class Contract
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string TenantName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public string Status { get; set; } // Активный, Завершен, Расторгнут

        public Contract(int id, int propertyId, string tenantName, DateTime startDate, DateTime endDate, decimal monthlyRent)
        {
            Id = id;
            PropertyId = propertyId;
            TenantName = tenantName;
            StartDate = startDate;
            EndDate = endDate;
            MonthlyRent = monthlyRent;
            Status = "Активный";
        }

        public override string ToString()
        {
            return $"ID: {Id} | Объект ID: {PropertyId} | Арендатор: {TenantName} | " +
                   $"Период: {StartDate:dd.MM.yyyy} - {EndDate:dd.MM.yyyy} | " +
                   $"Аренда: {MonthlyRent} руб./мес. | Статус: {Status}";
        }
    }
}