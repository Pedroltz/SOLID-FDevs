namespace SOLID.OCP.Violation
{
    // VIOLAÇÃO DO OCP: Esta classe precisa ser MODIFICADA sempre que surgir um novo tipo de cliente
    // OCP = Open/Closed Principle (Princípio Aberto/Fechado)
    // Classes devem estar ABERTAS para extensão, mas FECHADAS para modificação
    // 
    // PROBLEMA: Se eu quiser adicionar um novo tipo de cliente (ex: "Empresarial"),
    // vou ter que MODIFICAR esta classe, adicionando um novo "case" no switch
    // Isso quebra o princípio porque estou modificando código que já funcionava
    public class CalculadoraDescontoViolacao
    {
        public decimal CalcularDesconto(decimal valor, string tipoCliente)
        {
            // Este switch precisa ser MODIFICADO toda vez que surgir um novo tipo
            switch (tipoCliente)
            {
                case "Regular":
                    return valor * 0.02m; // 2% de desconto
                
                case "Premium":
                    return valor * 0.05m; // 5% de desconto
                
                case "VIP":
                    return valor * 0.10m; // 10% de desconto
                
                // E se quisermos adicionar "Empresarial"? 
                // Vamos ter que MODIFICAR esta classe!
                // case "Empresarial":
                //     return valor * 0.15m;
                
                default:
                    return 0m; // Sem desconto
            }
        }
    }

    // PROBLEMAS DESTA ABORDAGEM:
    // 1. Toda vez que surge um novo tipo, modifico a classe existente
    // 2. Risco de quebrar o código que já funcionava
    // 3. Preciso lembrar de todos os lugares onde uso tipos de cliente
    // 4. Dificulta testes (preciso testar tudo de novo a cada mudança)
    // 5. Viola o princípio da responsabilidade única também
    //
    // ANALOGIA: É como ter um funcionário que precisa aprender uma nova função
    // toda vez que a empresa contrata um novo tipo de cliente.
    // Se ele esquecer uma regra antiga enquanto aprende a nova, pode dar problema!
}