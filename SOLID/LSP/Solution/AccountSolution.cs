using System;

namespace SOLID.LSP.Solution
{
    // SOLUÇÃO DO LSP: Todas as subclasses podem substituir completamente a classe pai
    // Agora QUALQUER tipo de conta pode ser usado no lugar de ContaBancaria
    // sem quebrar o funcionamento do sistema

    // CLASSE BASE: Define comportamento comum que TODAS as contas devem seguir
    public abstract class ContaBancaria
    {
        public string Numero { get; set; }
        public decimal Saldo { get; set; }

        // Método que todas as contas implementam do mesmo jeito básico
        public virtual void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser positivo");
                
            Saldo += valor;
        }

        // Método abstrato = cada tipo implementa, mas SEM adicionar restrições extras
        public abstract bool PodeSacar(decimal valor);
        public abstract void Sacar(decimal valor);
    }

    // TIPO 1: Conta Corrente - permite saque sempre que tem saldo
    public class ContaCorrente : ContaBancaria
    {
        public override bool PodeSacar(decimal valor)
        {
            return valor <= Saldo;
        }

        public override void Sacar(decimal valor)
        {
            if (!PodeSacar(valor))
                throw new InvalidOperationException("Saldo insuficiente");
                
            Saldo -= valor;
        }
    }

    // TIPO 2: Conta Poupança - tem suas próprias regras, mas não quebra o contrato
    public class ContaPoupanca : ContaBancaria
    {
        // Regras específicas da poupança, mas sem quebrar o comportamento esperado
        public override bool PodeSacar(decimal valor)
        {
            // Poupança permite saque, mas pode ter regras internas diferentes
            return valor <= Saldo;
        }

        public override void Sacar(decimal valor)
        {
            if (!PodeSacar(valor))
                throw new InvalidOperationException("Saldo insuficiente");
                
            // Pode ter lógica específica (ex: registrar que é saque de poupança)
            // mas não adiciona restrições que quebrem a expectativa básica
            Saldo -= valor;
        }
    }

    // TIPO 3: Conta Investimento - também segue o contrato básico
    public class ContaInvestimento : ContaBancaria
    {
        public override bool PodeSacar(decimal valor)
        {
            // Pode ter lógica própria, mas não quebra a expectativa básica
            return valor <= Saldo;
        }

        public override void Sacar(decimal valor)
        {
            if (!PodeSacar(valor))
                throw new InvalidOperationException("Saldo insuficiente");
                
            Saldo -= valor;
        }
    }

    // AGORA ESTA CLASSE FUNCIONA COM QUALQUER TIPO DE CONTA!
    public class ProcessadorTransacao
    {
        public void ProcessarSaque(ContaBancaria conta, decimal valor)
        {
            // Este código funciona com QUALQUER subclasse de ContaBancaria
            // porque todas seguem o mesmo contrato básico
            if (conta.PodeSacar(valor))
            {
                conta.Sacar(valor);
                Console.WriteLine($"Saque realizado: R$ {valor:F2}");
            }
            else
            {
                Console.WriteLine("Saque não permitido");
            }
        }

        public void ProcessarDeposito(ContaBancaria conta, decimal valor)
        {
            // Também funciona com qualquer tipo de conta
            conta.Depositar(valor);
            Console.WriteLine($"Depósito realizado: R$ {valor:F2}");
        }
    }

    // AGORA ESTÁ CORRETO! Porque:
    // 
    // 1. Todas as subclasses seguem o mesmo contrato da classe pai
    // 2. Posso substituir ContaBancaria por qualquer subclasse sem quebrar
    // 3. Cada tipo pode ter suas particularidades, mas sem violar expectativas
    // 4. Código cliente funciona com qualquer tipo de conta
    // 5. Fácil adicionar novos tipos de conta
    //
    // VANTAGENS:
    // - Substituição transparente entre tipos de conta
    // - Código mais confiável e previsível
    // - Fácil manutenção e extensão
    // - Polimorfismo funciona corretamente
    //
    // ANALOGIA: Agora todos os "funcionários vendedores" seguem as mesmas regras básicas:
    // - Todos podem atender clientes
    // - Todos podem fazer vendas
    // - Cada um pode ter especialidades próprias
    // - Mas todos funcionam como "vendedores" quando preciso de um
    // Se substituo um vendedor por outro, o sistema continua funcionando!
}