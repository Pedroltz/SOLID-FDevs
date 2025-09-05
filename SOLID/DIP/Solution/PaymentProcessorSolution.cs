using System;
using System.Collections.Generic;

namespace SOLID.DIP.Solution
{
    // SOLUÇÃO DO DIP: Classes de alto nível dependem de abstrações, não de implementações
    // Agora ProcessadorPagamento não conhece detalhes específicos de cada método!
    // Todos dependem da mesma interface (abstração)

    // ABSTRAÇÃO: Interface que define o "contrato" comum para todos os pagamentos
    public interface IProcessadorPagamento
    {
        void ProcessarPagamento(decimal valor);
        string ObterNome();
    }

    // IMPLEMENTAÇÕES: Cada método de pagamento implementa a interface do seu jeito
    public class PayPal : IProcessadorPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Processando R$ {valor:F2} via PayPal");
        }

        public string ObterNome()
        {
            return "PayPal";
        }
    }

    public class PicPay : IProcessadorPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Efetuando R$ {valor:F2} via PicPay");
        }

        public string ObterNome()
        {
            return "PicPay";
        }
    }

    public class CartaoCredito : IProcessadorPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Cobrando R$ {valor:F2} no cartão de crédito");
        }

        public string ObterNome()
        {
            return "Cartão de Crédito";
        }
    }

    // NOVO MÉTODO: PIX - posso adicionar sem modificar nenhuma classe existente!
    public class PIX : IProcessadorPagamento
    {
        public void ProcessarPagamento(decimal valor)
        {
            Console.WriteLine($"Transferindo R$ {valor:F2} via PIX");
        }

        public string ObterNome()
        {
            return "PIX";
        }
    }

    // AGORA: Classe de ALTO NÍVEL depende apenas da ABSTRAÇÃO!
    public class ProcessadorPagamentoSolucao
    {
        // Dependência da INTERFACE, não de classes específicas
        private readonly List<IProcessadorPagamento> metodosDisponiveis;

        // INVERSÃO: As dependências são INJETADAS, não criadas internamente
        public ProcessadorPagamentoSolucao(List<IProcessadorPagamento> metodos)
        {
            metodosDisponiveis = metodos ?? new List<IProcessadorPagamento>();
        }

        public void ProcessarPagamento(decimal valor, string nomeMetodo)
        {
            // Busca o método sem conhecer detalhes específicos
            var metodo = metodosDisponiveis.Find(m => 
                m.ObterNome().ToLower() == nomeMetodo.ToLower());

            if (metodo != null)
            {
                // Usa a abstração, não conhece implementação específica
                metodo.ProcessarPagamento(valor);
            }
            else
            {
                Console.WriteLine($"Método '{nomeMetodo}' não disponível");
            }
        }

        public void ListarMetodosDisponiveis()
        {
            Console.WriteLine("Métodos de pagamento disponíveis:");
            foreach (var metodo in metodosDisponiveis)
            {
                Console.WriteLine($"- {metodo.ObterNome()}");
            }
        }
    }

    // CLASSE PARA CONFIGURAR AS DEPENDÊNCIAS (Composition Root)
    public class ConfiguradorPagamentos
    {
        public static ProcessadorPagamentoSolucao CriarProcessador()
        {
            // Aqui configuramos quais métodos estarão disponíveis
            var metodos = new List<IProcessadorPagamento>
            {
                new PayPal(),
                new PicPay(),
                new CartaoCredito(),
                new PIX() // Fácil adicionar novos métodos!
            };

            return new ProcessadorPagamentoSolucao(metodos);
        }
    }

    // AGORA ESTÁ CORRETO! Porque:
    // 
    // 1. ProcessadorPagamento (alto nível) não conhece detalhes (baixo nível)
    // 2. Todos dependem da mesma abstração (IProcessadorPagamento)
    // 3. Fácil adicionar novos métodos sem modificar código existente
    // 4. Fácil testar (posso criar mocks da interface)
    // 5. Baixo acoplamento (classes não se conhecem diretamente)
    // 6. Flexível (posso trocar implementações facilmente)
    // 7. Dependências injetadas (flexível e testável)
    //
    // VANTAGENS:
    // - Processador não precisa saber como cada pagamento funciona
    // - Novo método? Só implementar a interface!
    // - Fácil testar com implementações fake
    // - Pode reutilizar em diferentes contextos
    // - Configuração centralizada e flexível
    //
    // ANALOGIA: Agora o gerente de vendas só precisa saber:
    // "Todos os métodos de pagamento têm a função 'processar'"
    // Ele não precisa saber como cada um funciona internamente.
    // Se surgir um novo método, só precisa implementar essa função básica.
    // O gerente continua trabalhando do mesmo jeito!
}