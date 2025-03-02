namespace JogoNumeroAleatorio.Source.Enums
{
    /// <summary>
    /// Define os possíveis resultados de uma tentativa no jogo de adivinhação.
    /// </summary>
    public enum StatusTentativa
    {
        /// <summary>
        /// Indica que o número informado pelo usuário está correto.
        /// </summary>
        Acertou,

        /// <summary>
        /// Indica que o número informado é maior que o número aleatório gerado.
        /// </summary>
        MuitoAlto,

        /// <summary>
        /// Indica que o número informado é menor que o número aleatório gerado.
        /// </summary>
        MuitoBaixo
    }
}