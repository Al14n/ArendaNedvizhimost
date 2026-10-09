using System;

namespace ArendaNedvizhimost
{
    public class Payment
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal RentAmount { get; set; }
        public decimal UtilitiesAmount { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }

        public Payment(int id, int contractId, DateTime paymentDate, decimal rentAmount, decimal utilitiesAmount, decimal penaltyAmount)
        {
            Id = id;
            ContractId = contractId;
            PaymentDate = paymentDate;
            RentAmount = rentAmount;
            UtilitiesAmount = utilitiesAmount;
            PenaltyAmount = penaltyAmount;
            TotalAmount = rentAmount + utilitiesAmount + penaltyAmount;
            IsPaid = false;
        }

        public override string ToString()
        {
            string status = IsPaid ? "Оплачено" : "Не оплачено";
            return $"ID: {Id} | Договор ID: {ContractId} | Дата: {PaymentDate:dd.MM.yyyy} | " +
                   $"Аренда: {RentAmount} руб. | Коммуналка: {UtilitiesAmount} руб. | " +
                   $"Пени: {PenaltyAmount} руб. | Итого: {TotalAmount} руб. | Статус: {status}";
        }
    }
}