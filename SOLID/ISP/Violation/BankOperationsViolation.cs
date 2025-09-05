using System;

namespace SOLID.ISP.Violation
{
    // VIOLAÇÃO DO ISP: Interface muito "gorda" que força classes a implementar métodos desnecessários
    // ISP = Interface Segregation Principle (Princípio da Segregação de Interface)
    // "Nenhum cliente deve ser forçado a depender de métodos que não utiliza"
    // 
    // Em palavras simples: Não force uma classe a implementar métodos que ela não precisa
    // É melhor ter várias interfaces pequenas e específicas do que uma interface gigante
    //
    // PROBLEMA: Esta interface obriga TODAS as classes a implementar TODOS os métodos!
    public interface IOperacoesBancarias
    {
        // Operações básicas - todos os tipos de conta precisam
        void Depositar(decimal valor);
        void Sacar(decimal valor);
        decimal ConsultarSaldo();
        
        // Operações de investimento - só contas de investimento precisam!
        void InvestirEmAcoes(decimal valor);
        void InvestirEmFundos(decimal valor);
        decimal ConsultarRendimento();
        
        // Operações de empréstimo - só contas corrente precisam!
        void SolicitarEmprestimo(decimal valor);
        decimal ConsultarLimiteEmprestimo();
        
        // Operações de poupança - só conta poupança precisa!
        void CalcularRendimentoPoupanca();
        DateTime ConsultarAniversarioPoupanca();
    }

    // PROBLEMA: ContaCorrente é FORÇADA a implementar métodos de investimento e poupança!
    public class ContaCorrente : IOperacoesBancarias
    {
        public decimal Saldo { get; set; }

        // Implementa porque precisa - OK
        public void Depositar(decimal valor) { Saldo += valor; }
        public void Sacar(decimal valor) { Saldo -= valor; }
        public decimal ConsultarSaldo() { return Saldo; }
        
        // Implementa porque precisa - OK  
        public void SolicitarEmprestimo(decimal valor) { /* Lógica de empréstimo */ }
        public decimal ConsultarLimiteEmprestimo() { return 10000m; }
        
        // FORÇADA a implementar métodos que NÃO fazem sentido para conta corrente!
        public void InvestirEmAcoes(decimal valor)
        {
            throw new NotImplementedException("Conta corrente não investe em ações!");
        }
        
        public void InvestirEmFundos(decimal valor)
        {
            throw new NotImplementedException("Conta corrente não investe em fundos!");
        }
        
        public decimal ConsultarRendimento()
        {
            throw new NotImplementedException("Conta corrente não tem rendimento!");
        }
        
        public void CalcularRendimentoPoupanca()
        {
            throw new NotImplementedException("Conta corrente não é poupança!");
        }
        
        public DateTime ConsultarAniversarioPoupanca()
        {
            throw new NotImplementedException("Conta corrente não tem aniversário!");
        }
    }

    // PROBLEMA: ContaPoupanca é FORÇADA a implementar métodos de investimento e empréstimo!
    public class ContaPoupanca : IOperacoesBancarias
    {
        public decimal Saldo { get; set; }
        
        // Implementa porque precisa - OK
        public void Depositar(decimal valor) { Saldo += valor; }
        public void Sacar(decimal valor) { Saldo -= valor; }
        public decimal ConsultarSaldo() { return Saldo; }
        
        // Implementa porque precisa - OK
        public void CalcularRendimentoPoupanca() { /* Lógica de rendimento */ }
        public DateTime ConsultarAniversarioPoupanca() { return DateTime.Now.AddMonths(1); }
        
        // FORÇADA a implementar métodos que NÃO fazem sentido para poupança!
        public void InvestirEmAcoes(decimal valor)
        {
            throw new NotImplementedException("Poupança não investe em ações!");
        }
        
        public void InvestirEmFundos(decimal valor) 
        {
            throw new NotImplementedException("Poupança não investe em fundos!");
        }
        
        public decimal ConsultarRendimento()
        {
            throw new NotImplementedException("Poupança tem rendimento próprio!");
        }
        
        public void SolicitarEmprestimo(decimal valor)
        {
            throw new NotImplementedException("Poupança não faz empréstimo!");
        }
        
        public decimal ConsultarLimiteEmprestimo()
        {
            throw new NotImplementedException("Poupança não tem limite!");
        }
    }

    // PROBLEMAS DESTA ABORDAGEM:
    // 1. Classes implementam métodos que não fazem sentido para elas
    // 2. Muito código com NotImplementedException (sinal de design ruim)
    // 3. Interface gigante dificulta manutenção e entendimento
    // 4. Mudança em qualquer operação afeta TODAS as classes
    // 5. Dificulta testes (precisa testar métodos inúteis)
    // 6. Viola também o SRP (interface faz muitas coisas)
    //
    // ANALOGIA: É como ter um "contrato de funcionário" que obriga:
    // - Cozinheiro a saber dirigir caminhão
    // - Motorista a saber cozinhar  
    // - Contador a saber consertar equipamentos
    // - Técnico a saber contabilidade
    // Todo mundo assina o mesmo contrato gigante, mas usa só uma parte!
}