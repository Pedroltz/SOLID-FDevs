using System;

namespace SOLID.ISP.Solution
{
    // SOLUÇÃO DO ISP: Várias interfaces pequenas e específicas
    // Agora cada classe implementa apenas os métodos que realmente precisa!
    // Interfaces menores = mais fácil de entender, manter e testar

    // INTERFACE 1: Operações básicas que TODA conta precisa
    public interface IOperacoesBasicas
    {
        void Depositar(decimal valor);
        void Sacar(decimal valor);
        decimal ConsultarSaldo();
    }

    // INTERFACE 2: Operações de investimento - só quem investe implementa
    public interface IOperacoesInvestimento
    {
        void InvestirEmAcoes(decimal valor);
        void InvestirEmFundos(decimal valor);
        decimal ConsultarRendimento();
    }

    // INTERFACE 3: Operações de empréstimo - só quem empresta implementa
    public interface IOperacoesEmprestimo
    {
        void SolicitarEmprestimo(decimal valor);
        decimal ConsultarLimiteEmprestimo();
    }

    // INTERFACE 4: Operações de poupança - só conta poupança implementa
    public interface IOperacoesPoupanca
    {
        void CalcularRendimentoPoupanca();
        DateTime ConsultarAniversarioPoupanca();
    }

    // AGORA ContaCorrente só implementa o que precisa!
    public class ContaCorrente : IOperacoesBasicas, IOperacoesEmprestimo
    {
        public decimal Saldo { get; set; }

        // Operações básicas - implementa porque precisa
        public void Depositar(decimal valor) { Saldo += valor; }
        public void Sacar(decimal valor) { Saldo -= valor; }
        public decimal ConsultarSaldo() { return Saldo; }

        // Operações de empréstimo - implementa porque precisa
        public void SolicitarEmprestimo(decimal valor) 
        { 
            Console.WriteLine($"Empréstimo de R$ {valor:F2} solicitado"); 
        }
        public decimal ConsultarLimiteEmprestimo() { return 10000m; }

        // NÃO precisa implementar investimento nem poupança!
        // Código mais limpo e focado!
    }

    // AGORA ContaPoupanca só implementa o que precisa!
    public class ContaPoupanca : IOperacoesBasicas, IOperacoesPoupanca
    {
        public decimal Saldo { get; set; }

        // Operações básicas - implementa porque precisa
        public void Depositar(decimal valor) { Saldo += valor; }
        public void Sacar(decimal valor) { Saldo -= valor; }
        public decimal ConsultarSaldo() { return Saldo; }

        // Operações de poupança - implementa porque precisa
        public void CalcularRendimentoPoupanca() 
        { 
            Console.WriteLine("Rendimento da poupança calculado"); 
        }
        public DateTime ConsultarAniversarioPoupanca() { return DateTime.Now.AddMonths(1); }

        // NÃO precisa implementar empréstimo nem investimento!
        // Código mais limpo e focado!
    }

    // NOVA: ContaInvestimento só implementa o que precisa!
    public class ContaInvestimento : IOperacoesBasicas, IOperacoesInvestimento
    {
        public decimal Saldo { get; set; }

        // Operações básicas - implementa porque precisa
        public void Depositar(decimal valor) { Saldo += valor; }
        public void Sacar(decimal valor) { Saldo -= valor; }
        public decimal ConsultarSaldo() { return Saldo; }

        // Operações de investimento - implementa porque precisa
        public void InvestirEmAcoes(decimal valor) 
        { 
            Console.WriteLine($"Investindo R$ {valor:F2} em ações"); 
        }
        public void InvestirEmFundos(decimal valor) 
        { 
            Console.WriteLine($"Investindo R$ {valor:F2} em fundos"); 
        }
        public decimal ConsultarRendimento() { return Saldo * 0.1m; }

        // NÃO precisa implementar empréstimo nem poupança!
        // Código mais limpo e focado!
    }

    // NOVA: Conta super completa que implementa tudo (se quiser)
    public class ContaCompleta : IOperacoesBasicas, IOperacoesInvestimento, 
                                IOperacoesEmprestimo, IOperacoesPoupanca
    {
        public decimal Saldo { get; set; }

        // Esta conta ESCOLHEU implementar todas as operações
        // Mas outras contas não são forçadas a fazer isso!
        
        public void Depositar(decimal valor) { Saldo += valor; }
        public void Sacar(decimal valor) { Saldo -= valor; }
        public decimal ConsultarSaldo() { return Saldo; }
        
        public void InvestirEmAcoes(decimal valor) { Console.WriteLine($"Investindo R$ {valor:F2} em ações"); }
        public void InvestirEmFundos(decimal valor) { Console.WriteLine($"Investindo R$ {valor:F2} em fundos"); }
        public decimal ConsultarRendimento() { return Saldo * 0.1m; }
        
        public void SolicitarEmprestimo(decimal valor) { Console.WriteLine($"Empréstimo de R$ {valor:F2} aprovado"); }
        public decimal ConsultarLimiteEmprestimo() { return 50000m; }
        
        public void CalcularRendimentoPoupanca() { Console.WriteLine("Rendimento calculado"); }
        public DateTime ConsultarAniversarioPoupanca() { return DateTime.Now.AddMonths(1); }
    }

    // AGORA ESTÁ CORRETO! Porque:
    // 
    // 1. Cada classe implementa apenas o que precisa
    // 2. Interfaces pequenas e focadas
    // 3. Fácil de entender cada interface
    // 4. Fácil adicionar novas operações sem afetar classes existentes
    // 5. Sem NotImplementedException
    // 6. Código mais limpo e organizado
    // 7. Testes mais focados
    //
    // VANTAGENS:
    // - Classes não são forçadas a implementar métodos inúteis
    // - Interfaces pequenas são mais fáceis de entender
    // - Mudanças em uma operação não afetam classes que não usam ela
    // - Código mais limpo sem métodos "fake"
    // - Fácil combinar interfaces conforme a necessidade
    //
    // ANALOGIA: Agora temos "contratos especializados":
    // - Contrato de cozinheiro (só operações de cozinha)
    // - Contrato de motorista (só operações de direção)  
    // - Contrato de contador (só operações financeiras)
    // - Se alguém quiser ser cozinheiro E motorista, assina os dois contratos
    // Mas quem só cozinha não é obrigado a dirigir!
}