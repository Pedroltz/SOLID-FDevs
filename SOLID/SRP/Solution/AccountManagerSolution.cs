namespace SOLID.SRP.Solution
{
    // SOLUÇÃO DO SRP: Cada classe tem apenas UMA responsabilidade!
    // Agora separamos tudo em classes especializadas

    // CLASSE 1: Só cuida de operações bancárias
    // Se mudarem as regras da conta, só mexo aqui
    public class ContaBancaria
    {
        public string Numero { get; set; }
        public string Cliente { get; set; }
        public decimal Saldo { get; set; }

        // Esta classe SÓ faz operações de conta
        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            Saldo -= valor;
        }
    }

    // CLASSE 2: Só cuida de enviar emails
    // Se mudarem a forma de enviar email, só mexo aqui
    public class ServicoEmail
    {
        public void EnviarEmail(string destinatario, string mensagem)
        {
            // Esta classe SÓ faz envio de email
        }
    }

    // CLASSE 3: Só cuida de salvar dados
    // Se mudarem o banco de dados, só mexo aqui  
    public class RepositorioConta
    {
        public void SalvarNoBanco(ContaBancaria conta)
        {
            // Esta classe SÓ faz operações de banco de dados
        }
    }

    // CLASSE 4: Só cuida de relatórios
    // Se mudarem o formato do relatório, só mexo aqui
    public class ServicoRelatorio
    {
        public void GerarRelatorio(ContaBancaria conta)
        {
            // Esta classe SÓ faz relatórios
        }
    }

    // AGORA ESTÁ CORRETO! Porque:
    // 
    // 1. ContaBancaria só muda se mudarem regras bancárias
    // 2. ServicoEmail só muda se mudarem regras de email
    // 3. RepositorioConta só muda se mudarem regras de dados
    // 4. ServicoRelatorio só muda se mudarem regras de relatórios
    //
    // VANTAGENS:
    // - Posso mexer no email sem afetar a conta
    // - Posso mexer no banco sem afetar o email
    // - Posso mexer no relatório sem afetar nada
    // - Cada desenvolvedor pode trabalhar numa classe diferente
    // - Fica muito mais fácil encontrar bugs
    //
    // ANALOGIA: Agora temos funcionários especializados:
    // - Caixa do banco (só cuida de dinheiro)
    // - Atendente de telemarketing (só cuida de comunicação)
    // - Técnico de TI (só cuida de computadores) 
    // - Contador (só cuida de relatórios)
}