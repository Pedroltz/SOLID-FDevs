using System;

namespace SOLID.LSP.Violation
{
    // VIOLAÇÃO DO LSP: As subclasses NÃO podem substituir completamente a classe pai
    // LSP = Liskov Substitution Principle (Princípio da Substituição de Liskov)
    // "Se S é um subtipo de T, então objetos do tipo T podem ser substituídos por objetos do tipo S"
    // 
    // Em palavras simples: Se eu tenho uma classe filha, ela deve funcionar EXATAMENTE
    // como a classe pai em todos os lugares onde a classe pai é usada
    //
    // PROBLEMA: A classe ContaPoupanca quebra essa regra!
    public abstract class ContaBancaria
    {
        public string Numero { get; set; }
        public decimal Saldo { get; set; }

        // Método que TODAS as contas devem ter
        public virtual void Sacar(decimal valor)
        {
            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente");
                
            Saldo -= valor;
        }

        public virtual void Depositar(decimal valor)
        {
            Saldo += valor;
        }
    }

    // Conta corrente funciona normalmente
    public class ContaCorrente : ContaBancaria
    {
        // Funciona igual à classe pai - OK!
        public override void Sacar(decimal valor)
        {
            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente");
                
            Saldo -= valor;
        }
    }

    // PROBLEMA: Esta classe quebra o LSP!
    public class ContaPoupanca : ContaBancaria
    {
        // VIOLAÇÃO: Adiciona uma nova restrição que não existia na classe pai!
        // A classe pai permite saque a qualquer momento, mas esta não
        public override void Sacar(decimal valor)
        {
            // Nova regra: só pode sacar após dia 30 do mês
            if (DateTime.Now.Day < 30)
                throw new InvalidOperationException("Conta poupança só permite saque após dia 30");
                
            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente");
                
            Saldo -= valor;
        }
    }

    // PROBLEMA EM AÇÃO: Este código quebra quando usa ContaPoupanca!
    public class ProcessadorTransacao
    {
        public void ProcessarSaque(ContaBancaria conta, decimal valor)
        {
            // Este código funciona com ContaCorrente
            // Mas QUEBRA com ContaPoupanca se não for dia 30!
            // Isso viola o LSP porque a subclasse não pode substituir a classe pai
            conta.Sacar(valor);
        }
    }

    // PROBLEMAS DESTA ABORDAGEM:
    // 1. ContaPoupanca adiciona restrições que não existiam na classe pai
    // 2. Código que funciona com ContaBancaria pode quebrar com ContaPoupanca
    // 3. Não posso substituir ContaBancaria por ContaPoupanca em todos os casos
    // 4. Viola a expectativa de que subclasses funcionem como a classe pai
    // 
    // ANALOGIA: É como ter um funcionário "Vendedor" e contratar um "Vendedor Especial"
    // que só trabalha às sextas-feiras. Se eu substituir um vendedor normal pelo especial,
    // meu sistema de vendas para de funcionar nos outros dias da semana!
}