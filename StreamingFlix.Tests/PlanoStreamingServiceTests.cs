using StreamingFlix.App;

namespace StreamingFlix.Tests;

public class PlanoStreamingServiceTests
{
    private readonly PlanoStreamingService _service = new PlanoStreamingService();

    // ─────────────────────────────────────────────────────────────
    // Teste 1: Classificação de Planos
    // ─────────────────────────────────────────────────────────────
    [Theory]
    [InlineData(1, "BÁSICO")]
    [InlineData(2, "PADRÃO")]
    [InlineData(4, "PREMIUM")]
    public void ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta(int telasSimultaneas, string classificacaoEsperada)
    {
        // Act
        string resultado = _service.ObterClassificacaoPorQualidade(telasSimultaneas);

        // Assert
        Assert.Equal(classificacaoEsperada, resultado);
    }

    // ─────────────────────────────────────────────────────────────
    // Teste 2: Cálculo de Desconto na Mensalidade
    // ─────────────────────────────────────────────────────────────
    [Theory]
    [InlineData(50, 1, 50)]   // sem desconto
    [InlineData(50, 6, 45)]   // 10% de desconto
    [InlineData(50, 12, 40)]  // 20% de desconto
    public void CalcularMensalidadeComDesconto_DeveAplicarDescontoCorreto(int valorBase, int mesesContratados, int valorEsperado)
    {
        // Act
        int resultado = _service.CalcularMensalidadeComDesconto(valorBase, mesesContratados);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    // ─────────────────────────────────────────────────────────────
    // Teste 3: Validação de Acesso a Conteúdo Adulto
    // ─────────────────────────────────────────────────────────────
    [Theory]
    [InlineData(20, false, true)]   // Maior de idade, sem restrição -> true
    [InlineData(20, true, false)]   // Maior de idade, com restrição -> false
    [InlineData(16, false, false)]  // Menor de idade -> false
    public void PodeAcessarConteudoAdulto_DeveValidarRegrasDeAcesso(int idade, bool controleParentalAtivo, bool resultadoEsperado)
    {
        // Act
        bool resultado = _service.PodeAcessarConteudoAdulto(idade, controleParentalAtivo);

        // Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
}
