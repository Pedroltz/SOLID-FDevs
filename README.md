# Projeto SOLID - Princípios de Programação Orientada a Objetos

## 🎯 Sobre o Projeto

Este projeto foi desenvolvido como parte do **Curso FDevs** e tem como objetivo demonstrar de forma prática e didática os **5 Princípios SOLID** da programação orientada a objetos, utilizando **C#** com exemplos do contexto financeiro.

## 📚 O que são os Princípios SOLID?

SOLID é um acrônimo que representa 5 princípios fundamentais para escrever código mais limpo, flexível e fácil de manter:

- **S** - Single Responsibility Principle (Princípio da Responsabilidade Única)
- **O** - Open/Closed Principle (Princípio Aberto/Fechado)
- **L** - Liskov Substitution Principle (Princípio da Substituição de Liskov)
- **I** - Interface Segregation Principle (Princípio da Segregação de Interface)
- **D** - Dependency Inversion Principle (Princípio da Inversão de Dependência)

## 🏗️ Estrutura do Projeto

```
SOLID/
├── SOLID/
│   ├── SRP/                # Single Responsibility Principle
│   │   ├── Violation/      # ❌ Como NÃO fazer
│   │   └── Solution/       # ✅ Como fazer corretamente
│   ├── OCP/                # Open/Closed Principle
│   │   ├── Violation/      # ❌ Como NÃO fazer
│   │   └── Solution/       # ✅ Como fazer corretamente
│   ├── LSP/                # Liskov Substitution Principle
│   │   ├── Violation/      # ❌ Como NÃO fazer
│   │   └── Solution/       # ✅ Como fazer corretamente
│   ├── ISP/                # Interface Segregation Principle
│   │   ├── Violation/      # ❌ Como NÃO fazer
│   │   └── Solution/       # ✅ Como fazer corretamente
│   └── DIP/                # Dependency Inversion Principle
│       ├── Violation/      # ❌ Como NÃO fazer
│       └── Solution/       # ✅ Como fazer corretamente
├── Program.cs              # Demonstrações práticas
├── SOLID.csproj           # Configuração do projeto
└── README.md              # Este arquivo
```

## 🔍 Detalhes dos Princípios

### 1. SRP - Single Responsibility Principle
**"Uma classe deve ter apenas uma razão para mudar"**

- **Violação**: Classe que faz tudo (operações bancárias + envio de email + relatórios + banco de dados)
- **Solução**: Classes especializadas, cada uma com uma responsabilidade específica
- **Analogia**: Em vez de um funcionário que faz tudo, ter especialistas em cada área

### 2. OCP - Open/Closed Principle  
**"Classes devem estar abertas para extensão, mas fechadas para modificação"**

- **Violação**: Switch/case que precisa ser modificado para cada novo tipo de cliente
- **Solução**: Herança e polimorfismo para adicionar novos tipos sem modificar código existente
- **Analogia**: Em vez de modificar funcionário existente, contratar especialista para nova área

### 3. LSP - Liskov Substitution Principle
**"Subclasses devem poder substituir suas classes pai sem quebrar o funcionamento"**

- **Violação**: Conta Poupança que adiciona restrições extras não presentes na classe pai
- **Solução**: Subclasses que respeitam o "contrato" da classe pai
- **Analogia**: Qualquer vendedor deve poder substituir outro vendedor sem quebrar o sistema

### 4. ISP - Interface Segregation Principle
**"Nenhuma classe deve ser forçada a implementar métodos que não utiliza"**

- **Violação**: Interface gigante que força todas as contas a implementar métodos de investimento, empréstimo, etc.
- **Solução**: Interfaces pequenas e específicas, cada classe implementa apenas o que precisa
- **Analogia**: Em vez de um contrato gigante, ter contratos especializados por função

### 5. DIP - Dependency Inversion Principle
**"Classes de alto nível não devem depender de classes de baixo nível. Ambas devem depender de abstrações"**

- **Violação**: Processador de pagamento que conhece diretamente PayPal, PicPay, etc.
- **Solução**: Interface comum e injeção de dependências
- **Analogia**: Gerente que trabalha com "processadores de pagamento" sem saber detalhes técnicos específicos

## 🚀 Como Executar

1. **Pré-requisitos**:
   - .NET Framework 4.7.2 ou superior
   - Visual Studio ou VS Code

2. **Execução**:
   ```bash
   # Clone ou baixe o projeto
   cd SOLID
   
   # Compile e execute
   dotnet run
   # ou abra no Visual Studio e pressione F5
   ```

3. **O que você verá**:
   - Demonstrações práticas de cada princípio
   - Comparação entre violação e solução
   - Exemplos com valores em reais
   - Explicações didáticas no console

## 💡 Características Didáticas

### Para Iniciantes
- **Código simples**: Foco no conceito, não na complexidade técnica
- **Comentários detalhados**: Explicações linha por linha
- **Analogias práticas**: Comparações com situações do dia a dia
- **Exemplos financeiros**: Contexto familiar e aplicável

### Abordagem Pedagógica
- **Violação primeiro**: Mostra o problema antes da solução
- **Comparação direta**: Lado a lado para ver a diferença
- **Exemplos práticos**: Situações reais de desenvolvimento
- **Linguagem acessível**: Sem jargões técnicos desnecessários

## 🎓 Curso FDevs

Este projeto faz parte do **Curso FDevs**, focado em formar desenvolvedores com sólida base em boas práticas de programação.

### Objetivos de Aprendizagem
- ✅ Entender os 5 princípios SOLID
- ✅ Identificar violações no código
- ✅ Aplicar soluções práticas
- ✅ Melhorar a qualidade do código
- ✅ Desenvolver pensamento arquitetural

## 🛠️ Tecnologias Utilizadas

- **C#** - Linguagem de programação
- **.NET Framework 4.7.2** - Plataforma de desenvolvimento
- **Console Application** - Tipo de projeto para simplicidade
- **POO** - Paradigma de programação orientada a objetos

## 📝 Licença

Este projeto foi desenvolvido para fins educacionais como parte do Curso FDevs.

---

**Desenvolvido com 💜 para o Curso FDevs**

*"Código limpo não é escrito seguindo regras. Código limpo é escrito por programadores que se importam."* - Robert C. Martin