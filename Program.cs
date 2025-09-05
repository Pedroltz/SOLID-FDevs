using System;
using SOLID.SRP.Violation;
using SOLID.SRP.Solution;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMONSTRAÇÃO DOS PRINCÍPIOS SOLID ===\n");

            Console.WriteLine("1. SRP - Single Responsibility Principle");
            Console.WriteLine("==========================================");

            DemonstrateSRP();

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void DemonstrateSRP()
        {
            Console.WriteLine("\n--- VIOLAÇÃO DO SRP ---");
            var accountViolation = new AccountManagerViolation("12345", "João Silva", 1000m);
            
            accountViolation.Deposit(500m);
            Console.WriteLine($"Saldo após depósito: R$ {accountViolation.Balance:F2}");
            
            accountViolation.GenerateReport();
            accountViolation.SendEmail("Depósito realizado com sucesso!");
            accountViolation.SaveToDatabase();

            Console.WriteLine("\n--- SOLUÇÃO DO SRP ---");
            var account = new Account("12345", "João Silva", 1000m);
            var emailService = new EmailService();
            var repository = new AccountRepository();
            var reportService = new ReportService();

            account.Deposit(500m);
            Console.WriteLine($"Saldo após depósito: R$ {account.Balance:F2}");

            reportService.GenerateReport(account);
            emailService.SendEmail(account.CustomerName, "Depósito realizado com sucesso!");
            repository.SaveToDatabase(account);
        }
    }
}