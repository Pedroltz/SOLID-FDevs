using System;
using SOLID.SRP.Violation;
using SOLID.SRP.Solution;
using SOLID.OCP.Violation;
using SOLID.OCP.Solution;
using SOLID.LSP.Violation;
using SOLID.LSP.Solution;
using SOLID.ISP.Violation;
using SOLID.ISP.Solution;

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

            Console.WriteLine("\n\n3. LSP - Liskov Substitution Principle");
            Console.WriteLine("=======================================");
            DemonstrateLSP();

            Console.WriteLine("\n\n4. ISP - Interface Segregation Principle");
            Console.WriteLine("=========================================");
            DemonstrateISP();

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

        static void DemonstrateLSP()
        {
            Console.WriteLine("\n--- VIOLAÇÃO DO LSP ---");
            var processadorViolacao = new SOLID.LSP.Violation.ProcessadorTransacao();
            
            Console.WriteLine("Testando ContaCorrente:");
            var contaCorrente1 = new SOLID.LSP.Violation.ContaCorrente();
            contaCorrente1.Numero = "001";
            contaCorrente1.Saldo = 1000m;
            
            try
            {
                processadorViolacao.ProcessarSaque(contaCorrente1, 500m);
                Console.WriteLine("Saque OK - Saldo: R$ " + contaCorrente1.Saldo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            Console.WriteLine("\nTestando ContaPoupanca (MESMO código):");
            var contaPoupanca1 = new SOLID.LSP.Violation.ContaPoupanca();
            contaPoupanca1.Numero = "002";
            contaPoupanca1.Saldo = 1000m;
            
            try
            {
                // PROBLEMA: Mesmo código quebra com ContaPoupanca!
                processadorViolacao.ProcessarSaque(contaPoupanca1, 500m);
                Console.WriteLine("Saque OK - Saldo: R$ " + contaPoupanca1.Saldo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            Console.WriteLine("PROBLEMA: Subclasse não pode substituir classe pai!");

            Console.WriteLine("\n--- SOLUÇÃO DO LSP ---");
            var processadorSolucao = new SOLID.LSP.Solution.ProcessadorTransacao();
            
            // Agora QUALQUER tipo de conta funciona com o MESMO código!
            var contaCorrente2 = new SOLID.LSP.Solution.ContaCorrente();
            contaCorrente2.Numero = "003";
            contaCorrente2.Saldo = 1000m;
            
            var contaPoupanca2 = new SOLID.LSP.Solution.ContaPoupanca();
            contaPoupanca2.Numero = "004";
            contaPoupanca2.Saldo = 1000m;
            
            var contaInvestimento = new SOLID.LSP.Solution.ContaInvestimento();
            contaInvestimento.Numero = "005";
            contaInvestimento.Saldo = 1000m;

            Console.WriteLine("Testando todos os tipos com MESMO código:");
            processadorSolucao.ProcessarSaque(contaCorrente2, 300m);
            processadorSolucao.ProcessarSaque(contaPoupanca2, 200m);  
            processadorSolucao.ProcessarSaque(contaInvestimento, 150m);
            
            Console.WriteLine("VANTAGEM: Qualquer subclasse substitui a classe pai perfeitamente!");
        }

        static void DemonstrateISP()
        {
            Console.WriteLine("\n--- VIOLAÇÃO DO ISP ---");
            
            Console.WriteLine("ContaCorrente forçada a implementar métodos de investimento e poupança:");
            var contaCorrenteViolacao = new SOLID.ISP.Violation.ContaCorrente();
            contaCorrenteViolacao.Depositar(1000m);
            
            try
            {
                // Tentando usar método que não faz sentido para conta corrente
                contaCorrenteViolacao.InvestirEmAcoes(500m);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
            }

            Console.WriteLine("\nContaPoupanca forçada a implementar métodos de empréstimo e investimento:");
            var contaPoupancaViolacao = new SOLID.ISP.Violation.ContaPoupanca();
            contaPoupancaViolacao.Depositar(1000m);
            
            try
            {
                // Tentando usar método que não faz sentido para poupança
                contaPoupancaViolacao.SolicitarEmprestimo(2000m);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
            }
            Console.WriteLine("PROBLEMA: Interface gigante força implementação de métodos inúteis!");

            Console.WriteLine("\n--- SOLUÇÃO DO ISP ---");
            Console.WriteLine("Cada classe implementa apenas o que precisa:");
            
            // Conta Corrente - só operações básicas e empréstimo
            var contaCorrente = new SOLID.ISP.Solution.ContaCorrente();
            contaCorrente.Depositar(1000m);
            Console.WriteLine($"Conta Corrente - Saldo: R$ {contaCorrente.ConsultarSaldo():F2}");
            contaCorrente.SolicitarEmprestimo(5000m);
            Console.WriteLine($"Limite: R$ {contaCorrente.ConsultarLimiteEmprestimo():F2}");
            
            // Conta Poupança - só operações básicas e poupança
            var contaPoupanca = new SOLID.ISP.Solution.ContaPoupanca();
            contaPoupanca.Depositar(2000m);
            Console.WriteLine($"\nConta Poupança - Saldo: R$ {contaPoupanca.ConsultarSaldo():F2}");
            contaPoupanca.CalcularRendimentoPoupanca();
            Console.WriteLine($"Aniversário: {contaPoupanca.ConsultarAniversarioPoupanca():dd/MM/yyyy}");
            
            // Conta Investimento - só operações básicas e investimento
            var contaInvestimento = new SOLID.ISP.Solution.ContaInvestimento();
            contaInvestimento.Depositar(5000m);
            Console.WriteLine($"\nConta Investimento - Saldo: R$ {contaInvestimento.ConsultarSaldo():F2}");
            contaInvestimento.InvestirEmAcoes(1000m);
            contaInvestimento.InvestirEmFundos(500m);
            Console.WriteLine($"Rendimento: R$ {contaInvestimento.ConsultarRendimento():F2}");
            
            // Conta Completa - implementa todas as interfaces (opcionalmente)
            var contaCompleta = new SOLID.ISP.Solution.ContaCompleta();
            contaCompleta.Depositar(10000m);
            Console.WriteLine($"\nConta Completa - Saldo: R$ {contaCompleta.ConsultarSaldo():F2}");
            contaCompleta.SolicitarEmprestimo(3000m);
            contaCompleta.InvestirEmAcoes(2000m);
            contaCompleta.CalcularRendimentoPoupanca();
            
            Console.WriteLine("VANTAGEM: Cada classe só implementa métodos que realmente usa!");
        }
    }
}