namespace StreamingFlix.App;

/// <summary>
/// Serviço responsável pelas regras de planos, mensalidades e controle de acesso da StreamingFlix.
/// </summary>
public class PlanoStreamingService
{
    /// <summary>
    /// Retorna a classificação do plano conforme o número de telas simultâneas permitidas:
    /// - 1 tela: "BÁSICO"
    /// - 2 telas: "PADRÃO"
    /// - 4 ou mais telas: "PREMIUM"
    /// </summary>
    public string ObterClassificacaoPorQualidade(int telasSimultaneas)
    {
        if (telasSimultaneas == 1)
            return "BÁSICO";

        if (telasSimultaneas == 2)
            return "PADRÃO";

        if (telasSimultaneas >= 4)
            return "PREMIUM";

        return "DESCONHECIDO";
    }

    /// <summary>
    /// Calcula a mensalidade aplicando descontos conforme o período de fidelidade/contrato:
    /// - 6 a 11 meses: 10% de desconto
    /// - 12 meses ou mais: 20% de desconto
    /// - Menos de 6 meses: sem desconto
    /// </summary>
    public int CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)
    {
        if (mesesContratados >= 12)
        {
            return valorBase - (valorBase * 20 / 100);
        }

        if (mesesContratados >= 6)
        {
            return valorBase - (valorBase * 10 / 100);
        }

        return valorBase;
    }

    /// <summary>
    /// Valida se o perfil pode acessar conteúdo adulto.
    /// Retorna true apenas se a idade for >= 18 E o controle parental estiver desativado (false).
    /// </summary>
    public bool PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)
    {
        return idade >= 18 && !controleParentalAtivo;
    }
}
