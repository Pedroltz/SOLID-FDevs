using System;

namespace SOLID.DIP.Violation
{
    // VIOLAÇÃO DO DIP: Classe de alto nível depende diretamente de classes de baixo nível
    // DIP = Dependency Inversion Principle (Princípio da Inversão de Dependência)
    // "Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações"
    // "Abstrações não devem depender de detalhes. Detalhes devem depender de abstrações"
    // 
    // Em palavras simples: Classes importantes não devem conhecer detalhes específicos
    // de classes menos importantes. Use interfaces para desacoplar!
    //
    // PROBLEMA: ProcessadorPagamento conhece diretamente PayPal, PicPay, etc.

    // Classes de baixo nível (detalhes específicos de cada pagamento)
    public class PayPal
    {
        public void ProcessarPagamentoPayPal(decimal valor)
        {
            Console.WriteLine($"Processando R$ {valor:F2} via PayPal");
        }
    }

    public class PicPay
    {
        public void EfetuarPagamentoPicPay(decimal valor)
        {
            Console.WriteLine($"Efetuando R$ {valor:F2} via PicPay");
        }
    }

    public class CartaoCredito
    {
        public void CobrarCartao(decimal valor)
        {
            Console.WriteLine($"Cobrando R$ {valor:F2} no cartão de crédito");
        }
    }

    // PROBLEMA: Esta classe de ALTO NÍVEL depende diretamente das classes de BAIXO NÍVEL!
    public class ProcessadorPagamentoViolacao
    {
        // Dependências diretas e específicas - RUIM!
        private PayPal paypal;
        private PicPay picpay;
        private CartaoCredito cartao;

        public ProcessadorPagamentoViolacao()
        {
            // PROBLEMA: Cria as dependências diretamente (acoplamento forte)
            paypal = new PayPal();
            picpay = new PicPay();
            cartao = new CartaoCredito();
        }

        public void ProcessarPagamento(decimal valor, string metodo)
        {
            // PROBLEMA: Conhece detalhes específicos de cada método de pagamento
            switch (metodo.ToLower())
            {
                case "paypal":
                    paypal.ProcessarPagamentoPayPal(valor);
                    break;
                case "picpay":
                    picpay.EfetuarPagamentoPicPay(valor);
                    break;
                case "cartao":
                    cartao.CobrarCartao(valor);
                    break;
                default:
                    throw new ArgumentException("Método de pagamento não suportado");
            }
        }

        // PROBLEMA: Para adicionar novo método (ex: PIX), preciso:
        // 1. Modificar esta classe (viola OCP também)
        // 2. Adicionar nova dependência específica
        // 3. Modificar o switch
        // 4. Conhecer detalhes do novo método
    }

    // PROBLEMAS DESTA ABORDAGEM:
    // 1. ProcessadorPagamento (alto nível) conhece detalhes específicos (baixo nível)
    // 2. Difícil testar (como simular PayPal, PicPay, etc?)
    // 3. Difícil adicionar novos métodos de pagamento
    // 4. Alto acoplamento (tudo conectado diretamente)
    // 5. Viola também OCP (precisa modificar para adicionar novo método)
    // 6. Não pode reutilizar em contextos diferentes
    // 7. Dependências criadas no construtor (inflexível)
    //
    // ANALOGIA: É como um gerente de vendas que precisa saber EXATAMENTE como
    // funciona cada máquina de cartão, cada aplicativo de pagamento, etc.
    // Se surgir um novo método, o gerente precisa parar tudo para aprender
    // os detalhes técnicos específicos!
}