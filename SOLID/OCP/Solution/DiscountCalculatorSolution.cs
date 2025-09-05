namespace SOLID.OCP.Solution
{
    // SOLUÇÃO DO OCP: Agora posso ESTENDER funcionalidade sem MODIFICAR código existente
    // Classes estão ABERTAS para extensão (posso criar novos tipos)
    // Classes estão FECHADAS para modificação (não mexo no que já funciona)

    // CLASSE BASE: Define o "contrato" que todos os tipos de desconto devem seguir
    public abstract class CalculadoraDesconto
    {
        // Método abstrato = cada tipo de cliente vai implementar do seu jeito
        public abstract decimal CalcularDesconto(decimal valor);
    }

    // TIPO 1: Cliente Regular
    // Se mudarem as regras do cliente regular, só mexo aqui
    public class DescontoClienteRegular : CalculadoraDesconto
    {
        public override decimal CalcularDesconto(decimal valor)
        {
            return valor * 0.02m; // 2% de desconto
        }
    }

    // TIPO 2: Cliente Premium  
    // Se mudarem as regras do cliente premium, só mexo aqui
    public class DescontoClientePremium : CalculadoraDesconto
    {
        public override decimal CalcularDesconto(decimal valor)
        {
            return valor * 0.05m; // 5% de desconto
        }
    }

    // TIPO 3: Cliente VIP
    // Se mudarem as regras do cliente VIP, só mexo aqui
    public class DescontoClienteVIP : CalculadoraDesconto
    {
        public override decimal CalcularDesconto(decimal valor)
        {
            return valor * 0.10m; // 10% de desconto
        }
    }

    // TIPO 4: Cliente Empresarial (NOVO TIPO!)
    // VANTAGEM: Posso adicionar este novo tipo SEM modificar nenhuma classe existente!
    // Só crio uma nova classe que herda de CalculadoraDesconto
    public class DescontoClienteEmpresarial : CalculadoraDesconto
    {
        public override decimal CalcularDesconto(decimal valor)
        {
            return valor * 0.15m; // 15% de desconto
        }
    }

    // CLASSE QUE USA OS DESCONTOS
    // Esta classe também não precisa ser modificada quando surge um novo tipo
    public class ProcessadorPagamento
    {
        public decimal CalcularValorFinal(decimal valor, CalculadoraDesconto calculadora)
        {
            decimal desconto = calculadora.CalcularDesconto(valor);
            return valor - desconto;
        }
    }

    // AGORA ESTÁ CORRETO! Porque:
    // 
    // 1. Para adicionar novo tipo: só crio uma nova classe (EXTENSÃO)
    // 2. Não modifico as classes existentes (FECHADO para modificação)
    // 3. Cada tipo tem sua própria responsabilidade
    // 4. Fácil de testar cada tipo separadamente
    // 5. Sem risco de quebrar tipos existentes
    //
    // VANTAGENS:
    // - Novo tipo de cliente? Só criar nova classe!
    // - Código existente continua funcionando
    // - Fácil de manter e testar
    // - Cada desenvolvedor pode trabalhar num tipo diferente
    //
    // ANALOGIA: Agora é como ter funcionários especializados por tipo de cliente:
    // - Um atende clientes regulares
    // - Outro atende clientes premium  
    // - Outro atende VIPs
    // - Se surgir cliente empresarial, contrato outro funcionário especializado
    // Os funcionários antigos continuam fazendo o que sempre fizeram!
}