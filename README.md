# Projeto SOLID - Curso FDevs

Demonstração prática dos **5 Princípios SOLID** em C# com exemplos do contexto financeiro.

## 🎯 O que é SOLID?

- **S** - Single Responsibility (Uma responsabilidade por classe)
- **O** - Open/Closed (Aberto para extensão, fechado para modificação)  
- **L** - Liskov Substitution (Subclasses substituem classes pai)
- **I** - Interface Segregation (Interfaces pequenas e específicas)
- **D** - Dependency Inversion (Dependa de abstrações, não implementações)

## 🏗️ Estrutura

```
SOLID/
└── SOLID/
    ├── SRP/     # Responsabilidade única
    ├── OCP/     # Aberto/Fechado
    ├── LSP/     # Substituição de Liskov
    ├── ISP/     # Segregação de interface
    └── DIP/     # Inversão de dependência
```

Cada princípio tem pasta **Violation** (como NÃO fazer) e **Solution** (como fazer certo).

## 🔍 Exemplos rápidos

**SRP**: Em vez de uma classe fazer tudo, ter classes especializadas  
**OCP**: Adicionar novos tipos sem modificar código existente  
**LSP**: Subclasses funcionam igual à classe pai  
**ISP**: Cada classe implementa só métodos que precisa  
**DIP**: Usar interfaces em vez de classes específicas  

---
**Curso FDevs** - Desenvolvendo código limpo e profissional
