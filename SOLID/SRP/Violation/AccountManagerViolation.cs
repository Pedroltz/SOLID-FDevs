namespace SOLID.SRP.Violation
{
    // VIOLAÇÃO DO SRP: Esta classe faz MUITAS coisas diferentes!
    // SRP = Single Responsibility Principle (Princípio da Responsabilidade Única)
    // Uma classe deveria ter apenas UM motivo para mudar
    // Esta classe tem 4 motivos diferentes para mudar:
    // 1. Mudanças nas regras da conta bancária
    // 2. Mudanças na forma de enviar email  
    // 3. Mudanças na forma de salvar dados
    // 4. Mudanças na forma de fazer relatórios
    public class ContaBancariaViolacao
    {
        public string Numero { get; set; }
        public string Cliente { get; set; }
        public decimal Saldo { get; set; }

        // RESPONSABILIDADE 1: Operações da conta - OK estar aqui
        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            Saldo -= valor;
        }

        // RESPONSABILIDADE 2: Enviar email - NÃO deveria estar aqui!
        // Por que uma conta bancária sabe enviar email?
        public void EnviarEmail(string mensagem)
        {
            // Simula envio de email
        }

        // RESPONSABILIDADE 3: Salvar dados - NÃO deveria estar aqui!
        // Por que uma conta bancária sabe sobre banco de dados?
        public void SalvarNoBanco()
        {
            // Simula salvamento no banco
        }

        // RESPONSABILIDADE 4: Gerar relatórios - NÃO deveria estar aqui!
        // Por que uma conta bancária sabe fazer relatórios?
        public void GerarRelatorio()
        {
            // Simula geração de relatório
        }
    }

    // PROBLEMA: Se eu quiser mudar APENAS como enviamos email,
    // vou ter que mexer na classe da conta bancária!
    // Isso pode quebrar as operações de depósito/saque sem querer.

    // ANALOGIA: É como um funcionário que é:
    // - Caixa do banco
    // - Técnico de informática  
    // - Designer gráfico
    // - Gerente de marketing
    // Se ele sair de férias, TUDO para de funcionar!
}