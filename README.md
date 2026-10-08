# 🎬 StreamingFlix — Testes Parametrizados com xUnit (.NET 10)

Projeto da disciplina **Garantia da Qualidade de Software** que implementa as regras de negócio de uma plataforma de streaming fictícia (planos, mensalidades e controle de acesso) e as valida com **testes parametrizados em xUnit**.

## 📌 Visão Geral

A **StreamingFlix** é uma aplicação .NET organizada em uma solução com dois projetos:

- **`StreamingFlix.App`**: aplicação console que contém a classe `PlanoStreamingService`, responsável pelas regras de planos, mensalidades e controle de acesso.
- **`StreamingFlix.Tests`**: projeto de testes xUnit que valida cada regra com `[Theory]` e `[InlineData]`, cobrindo vários cenários com um único método de teste.

## 🧩 Regras de Negócio

### 1. Classificação do plano por telas simultâneas

`ObterClassificacaoPorQualidade(int telasSimultaneas)`

| Telas simultâneas | Classificação |
|-------------------|---------------|
| 1                 | `BÁSICO`      |
| 2                 | `PADRÃO`      |
| 4 ou mais         | `PREMIUM`     |
| Qualquer outro valor (ex.: 0, 3) | `DESCONHECIDO` |

### 2. Mensalidade com desconto de fidelidade

`CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)`

| Meses contratados | Desconto |
|-------------------|----------|
| Menos de 6        | Nenhum   |
| 6 a 11            | 10%      |
| 12 ou mais        | 20%      |

> O cálculo usa números inteiros (`int`), então o resultado é truncado, sem casas decimais.

### 3. Acesso a conteúdo adulto

`PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)`

Retorna `true` somente se a idade for **18 ou mais** **e** o controle parental estiver **desativado** (`false`).

## ⚙️ Requisitos Técnicos

| Requisito | Versão |
|-----------|--------|
| [.NET SDK](https://dotnet.microsoft.com/download) | **10.0** (`net10.0`) |
| Git | Qualquer versão recente |
| xUnit | 2.9.3 |
| Microsoft.NET.Test.Sdk | 17.14.1 |
| xunit.runner.visualstudio | 3.1.4 |
| coverlet.collector | 6.0.4 |

Para conferir a versão instalada do .NET:

```bash
dotnet --version
```

## 🚀 Como Clonar e Rodar a Aplicação

**1. Clone o repositório**

```bash
git clone https://github.com/MicheleUai/streaming-flix-xunit.git
```

**2. Entre na pasta do projeto**

```bash
cd streaming-flix-xunit
```

**3. Restaure as dependências**

```bash
dotnet restore
```

**4. Compile a solução**

```bash
dotnet build
```

**5. Execute a aplicação**

```bash
dotnet run --project StreamingFlix.App
```

> Neste momento o `Program.cs` é apenas o ponto de entrada do console (exibe `Hello, World!`). As regras de negócio ficam em `PlanoStreamingService` e são validadas pelos testes.

## 🧪 Como Executar os Testes Unitários

Na raiz do repositório, rode:

```bash
dotnet test
```

O comando compila a solução, executa todos os testes e mostra o resultado no terminal. O esperado é **100% dos cenários aprovados**.

Para ver o nome de cada teste executado:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Para gerar também a cobertura de código:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## ✅ Cobertura dos Testes Parametrizados

Os testes ficam em `StreamingFlix.Tests/PlanoStreamingServiceTests.cs`, seguem o padrão **Arrange / Act / Assert** e usam `[Theory]` com `[InlineData]`. São **3 testes parametrizados** que somam **9 cenários**, um por regra de negócio:

| Teste | Cenários (`InlineData`) | O que valida |
|-------|-------------------------|--------------|
| `ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta` | `1 → BÁSICO`<br>`2 → PADRÃO`<br>`4 → PREMIUM` | As três classificações de plano retornadas conforme o número de telas |
| `CalcularMensalidadeComDesconto_DeveAplicarDescontoCorreto` | `(50, 1) → 50`<br>`(50, 6) → 45`<br>`(50, 12) → 40` | Mensalidade sem desconto, com 10% e com 20% |
| `PodeAcessarConteudoAdulto_DeveValidarRegrasDeAcesso` | `(20, false) → true`<br>`(20, true) → false`<br>`(16, false) → false` | Acesso liberado, bloqueio por controle parental e bloqueio por idade |

Com isso, cada ramo principal das três regras é exercitado ao menos uma vez, e o uso de `[Theory]` evita duplicar código de teste para cada cenário.

## 🗂️ Estrutura do Projeto

```
streaming-flix-xunit/
├── StreamingFlix.App/
│   ├── PlanoStreamingService.cs        # Regras de negócio
│   ├── Program.cs
│   └── StreamingFlix.App.csproj
├── StreamingFlix.Tests/
│   ├── PlanoStreamingServiceTests.cs   # Testes parametrizados
│   └── StreamingFlix.Tests.csproj
├── StreamingFlix.slnx
├── .gitignore
├── LICENSE
└── README.md
```

## 👥 Equipe

| Nome | GitHub |
|---|---|
| Marcos | [@M4RCOSx15](https://github.com/M4RCOSx15) |
| Michelle | [@MicheleUai](https://github.com/MicheleUai) |
| Vinícius Henrique Diniz Bento | [@Viniciushdb](https://github.com/Viniciushdb) |

## 📄 Licença

Distribuído sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
