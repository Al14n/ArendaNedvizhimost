using System;
using System.Collections.Generic;
using System.Linq;

namespace ArendaNedvizhimost
{
    public class PaymentManager
    {
        private List<Payment> payments = new List<Payment>();
        private int nextId = 1;
        private ContractManager contractManager;

        public PaymentManager(ContractManager contractManager)
        {
            this.contractManager = contractManager;
        }

        public void CalculatePayment()
        {
            Console.WriteLine("\n--- Начисление платежа ---");

            Console.WriteLine("\nАктивные договоры:");
            var activeContracts = contractManager.GetActiveContracts();

            if (activeContracts.Count == 0)
            {
                Console.WriteLine("Активные договоры отсутствуют.");
                Console.ReadKey();
                return;
            }

            foreach (var contract in activeContracts)
            {
                Console.WriteLine(contract);
            }

            Console.Write("\nВведите ID договора для начисления: ");
            if (!int.TryParse(Console.ReadLine(), out int contractId))
            {
                Console.WriteLine("✗ Некорректный ID договора.");
                Console.ReadKey();
                return;
            }

            var selectedContract = activeContracts.FirstOrDefault(c => c.Id == contractId);
            if (selectedContract == null)
            {
                Console.WriteLine("Договор не найден или не активен.");
                Console.ReadKey();
                return;
            }

            Console.Write("Дата платежа (дд.мм.гггг): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime paymentDate))
            {
                Console.WriteLine("✗ Некорректная дата.");
                Console.ReadKey();
                return;
            }

            Console.Write("Коммунальные платежи (руб.): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal utilities))
            {
                Console.WriteLine("Некорректная сумма.");
                Console.ReadKey();
                return;
            }

            decimal penalty = 0;
            int daysOverdue = (int)(DateTime.Now - paymentDate).TotalDays;
            if (daysOverdue > 0)
            {
                penalty = selectedContract.MonthlyRent * 0.001m * daysOverdue;
                Console.WriteLine($"Начислены пени за {daysOverdue} дней: {penalty} руб.");
            }

            Payment payment = new Payment(nextId++, contractId, paymentDate, selectedContract.MonthlyRent, utilities, penalty);
            payments.Add(payment);

            Console.WriteLine($"\nПлатёж успешно начислен!");
            Console.WriteLine($"Итого к оплате: {payment.TotalAmount} руб.");
            Console.ReadKey();
        }

        public void ViewPayments()
        {
            Console.WriteLine("\n--- Все начисления ---");

            if (payments.Count == 0)
            {
                Console.WriteLine("Начисления отсутствуют.");
            }
            else
            {
                foreach (var payment in payments)
                {
                    Console.WriteLine(payment);
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void MarkAsPaid()
        {
            Console.WriteLine("\n--- Отметить платёж как оплаченный ---");

            if (payments.Count == 0)
            {
                Console.WriteLine("Начисления отсутствуют.");
                Console.ReadKey();
                return;
            }

            ViewPayments();

            Console.Write("\nВведите ID платежа для отметки об оплате: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var payment = payments.FirstOrDefault(p => p.Id == id);
                if (payment != null)
                {
                    if (payment.IsPaid)
                    {
                        Console.WriteLine("\nℹ Этот платёж уже оплачен.");
                    }
                    else
                    {
                        payment.IsPaid = true;
                        Console.WriteLine($"\nПлатёж ID {id} отмечен как оплаченный.");
                    }
                }
                else
                {
                    Console.WriteLine("\nПлатёж с таким ID не найден.");
                }
            }
            else
            {
                Console.WriteLine("\nНекорректный ID.");
            }

            Console.ReadKey();
        }

        public void ViewDebts()
        {
            Console.WriteLine("\n--- Задолженность по платежам ---");

            var unpaidPayments = payments.Where(p => !p.IsPaid).ToList();

            if (unpaidPayments.Count == 0)
            {
                Console.WriteLine("Задолженностей нет.");
            }
            else
            {
                decimal totalDebt = 0;
                foreach (var payment in unpaidPayments)
                {
                    Console.WriteLine(payment);
                    totalDebt += payment.TotalAmount;
                }
                Console.WriteLine($"\nОбщая задолженность: {totalDebt} руб.");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}