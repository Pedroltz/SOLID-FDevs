using System;
using SOLID.SRP.Violation;
using SOLID.SRP.Solution;
using SOLID.OCP.Violation;
using SOLID.OCP.Solution;

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

            Console.WriteLine("\n\n2. OCP - Open/Closed Principle");
            Console.WriteLine("===============================");
            DemonstrateOCP();

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void DemonstrateSRP()
        {
            Console.WriteLine("\n--- VIOLAÇÃO DO SRP ---");
            var accountViolation = new ContaBancariaViolacao();
            accountViolation.Numero = "12345";
            accountViolation.Cliente = "João Silva";
            accountViolation.Saldo = 1000m;
            
            accountViolation.Depositar(500m);
            Console.WriteLine($"Saldo após depósito: R$ {accountViolation.Saldo:F2}");
            Console.WriteLine("Classe faz TUDO: operações, email, banco, relatórios");

            Console.WriteLine("\n--- SOLUÇÃO DO SRP ---");
            var account = new ContaBancaria();
            account.Numero = "12345";
            account.Cliente = "João Silva";
            account.Saldo = 1000m;

            var emailService = new ServicoEmail();
            var repository = new RepositorioConta();
            var reportService = new ServicoRelatorio();

            account.Depositar(500m);
            Console.WriteLine($"Saldo após depósito: R$ {account.Saldo:F2}");
            Console.WriteLine("Agora cada classe tem UMA responsabilidade!");
        }

        static void DemonstrateOCP()
        {
            Console.WriteLine("\n--- VIOLAÇÃO DO OCP ---");
            var calculadoraViolacao = new CalculadoraDescontoViolacao();
            
            decimal valor = 1000m;
            Console.WriteLine($"Valor original: R$ {valor:F2}");
            Console.WriteLine($"Desconto Regular: R$ {calculadoraViolacao.CalcularDesconto(valor, "Regular"):F2}");
            Console.WriteLine($"Desconto Premium: R$ {calculadoraViolacao.CalcularDesconto(valor, "Premium"):F2}");
            Console.WriteLine($"Desconto VIP: R$ {calculadoraViolacao.CalcularDesconto(valor, "VIP"):F2}");
            Console.WriteLine("PROBLEMA: Para novo tipo, preciso MODIFICAR a classe!");

            Console.WriteLine("\n--- SOLUÇÃO DO OCP ---");
            var processador = new ProcessadorPagamento();
            
            // Posso criar novos tipos sem modificar código existente
            var regular = new DescontoClienteRegular();
            var premium = new DescontoClientePremium();
            var vip = new DescontoClienteVIP();
            var empresarial = new DescontoClienteEmpresarial(); // NOVO tipo!
            
            Console.WriteLine($"Valor original: R$ {valor:F2}");
            Console.WriteLine($"Regular - Final: R$ {processador.CalcularValorFinal(valor, regular):F2}");
            Console.WriteLine($"Premium - Final: R$ {processador.CalcularValorFinal(valor, premium):F2}");
            Console.WriteLine($"VIP - Final: R$ {processador.CalcularValorFinal(valor, vip):F2}");
            Console.WriteLine($"Empresarial - Final: R$ {processador.CalcularValorFinal(valor, empresarial):F2}");
            Console.WriteLine("VANTAGEM: Novo tipo sem modificar código existente!");
        }
    }
}