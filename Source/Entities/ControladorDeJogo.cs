using JogoNumeroAleatorio.Source.Enums;

namespace JogoNumeroAleatorio.Source.Entities
{
    /// <summary>
    /// Representa o controlador do jogo de adivinhação.
    /// Gerencia a geração do número aleatório e valida as tentativas do usuário.
    /// </summary>
    public class ControladorDeJogo
    {
        /// <summary>
        /// Número aleatório gerado que o usuário deve adivinhar.
        /// </summary>
        private int NumeroAleatorio { get; set; }

        /// <summary>
        /// Menor valor permitido para o número aleatório.
        /// </summary>
        private const int MenorNumeroAleatorioPermitido = 1;

        /// <summary>
        /// Maior valor permitido para o número aleatório.
        /// </summary>
        private const int MaiorNumeroAleatorioPermitido = 100;

        /// <summary>
        /// Obtém o número de tentativas realizadas até o acerto.
        /// </summary>
        public int TentativasAteAcertar { get; private set; }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ControladorDeJogo"/>.
        /// Gera o número aleatório e inicializa a contagem de tentativas.
        /// </summary>
        public ControladorDeJogo()
        {
            NumeroAleatorio = GerarNumeroAleatorio();
            TentativasAteAcertar = 0;
        }

        /// <summary>
        /// Gera um número aleatório entre os valores permitidos.
        /// </summary>
        /// <returns>
        /// Um número inteiro entre <see cref="MenorNumeroAleatorioPermitido"/> e <see cref="MaiorNumeroAleatorioPermitido"/>, inclusive.
        /// </returns>
        private static int GerarNumeroAleatorio()
        {
            // É preciso adicionar o valor "+1" para incluir o valor máximo estipulado no campo "MaiorNumeroAleatorioPermitido"
            // na geração do número aleatório.
            // Caso contrário o "MaiorNumeroAleatorioPermitido" não estaria incluso no intervalo.
            return Random.Shared.Next(MenorNumeroAleatorioPermitido, MaiorNumeroAleatorioPermitido + 1);
        }

        /// <summary>
        /// Verifica a tentativa do usuário comparando com o número aleatório gerado.
        /// Incrementa o contador de tentativas e retorna o status da tentativa.
        /// </summary>
        /// <param name="tentativa">Número informado pelo usuário.</param>
        /// <returns>
        /// Um valor do tipo <see cref="StatusTentativa"/> que indica se o número informado é maior, menor ou igual ao número gerado.
        /// </returns>
        public StatusTentativa AdvinharNumeroAleatorio(int tentativa)
        {
            TentativasAteAcertar++;

            return tentativa switch
            {
                _ when tentativa > NumeroAleatorio => StatusTentativa.MuitoAlto,
                _ when tentativa < NumeroAleatorio => StatusTentativa.MuitoBaixo,
                _ => StatusTentativa.Acertou
            };
        }
    }
}