using JogoNumeroAleatorio.Source.Entities;
using JogoNumeroAleatorio.Source.Enums;

try
{
    // Define a codificação do console para UTF-8, permitindo a exibição de caracteres Unicode, como emojis.
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\n🎲 Bem-vindo ao jogo de adivinhação!");
    Console.ForegroundColor = ConsoleColor.Green;

    ControladorDeJogo controladorDeJogo = new ControladorDeJogo();
    int tentativa = 0;
    StatusTentativa statusTentativa;

    do
    {
        tentativa = CapturarTentativaUsuario();
        statusTentativa = controladorDeJogo.AdvinharNumeroAleatorio(tentativa);

        ProcessarTentativa(statusTentativa);

    } while (statusTentativa != StatusTentativa.Acertou);

    Console.WriteLine($"🎯 Você acertou o número em {controladorDeJogo.TentativasAteAcertar} tentativas! 🏆");
}
catch (Exception erro)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n❌ Ocorreu um erro inesperado durante a execução do sistema: {erro.Message} ⚠️");
}
finally
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n\n🔚 Jogo finalizado. Obrigado por jogar e até a próxima! 🌟\n\n");
    Console.ForegroundColor = ConsoleColor.White;
}

/// <summary>
/// Captura a tentativa do usuário por meio da entrada no console.
/// </summary>
/// <returns>
/// Retorna o número informado pelo usuário, após validação.
/// </returns>
static int CapturarTentativaUsuario()
{
    Console.Write("\n🔢 Digite seu palpite: ");
    string? entradaUsuario = Console.ReadLine();

    return ValidarEntradaUsuario(entradaUsuario);
}

/// <summary>
/// Valida a entrada do usuário, convertendo a string informada em um número inteiro.
/// </summary>
/// <param name="entrada">Valor digitado pelo usuário no console.</param>
/// <returns>
/// O valor inteiro correspondente à entrada, caso seja válido.
/// </returns>
/// <exception cref="ArgumentException">
/// Lançada quando a entrada não pode ser convertida para um número inteiro.
/// </exception>
static int ValidarEntradaUsuario(string? entrada)
{
    if (!int.TryParse(entrada, out int entradaInteira))
        throw new ArgumentException($"O valor informado [{entrada}] é invalido.");

    return entradaInteira;
}

/// <summary>
/// Processa o status da tentativa do usuário e exibe a mensagem de feedback correspondente.
/// </summary>
/// <param name="statusTentativa">
/// Status retornado pela lógica do jogo, indicando se a tentativa foi maior, menor ou igual ao número gerado.
/// </param>
/// <exception cref="ArgumentException">
/// Lançada quando o status da tentativa não é reconhecido.
/// </exception>
static void ProcessarTentativa(StatusTentativa statusTentativa)
{
    var (mensagem, corTexto) = statusTentativa switch
    {
        StatusTentativa.Acertou => ("🎉 Parabéns! Você acertou! 🚀🚀🚀", ConsoleColor.Magenta),
        StatusTentativa.MuitoAlto => ("🔼 O número informado é muito alto. Tente um valor menor!", ConsoleColor.Yellow),
        StatusTentativa.MuitoBaixo => ("🔽 O número informado é muito baixo. Tente um valor maior!", ConsoleColor.Cyan),
        _ => throw new ArgumentException("Status de tentativa inválido.")
    };

    ExibirMensagemTentativa(mensagem, corTexto);
}

/// <summary>
/// Exibe a mensagem de feedback no console, alterando a cor do texto conforme especificado.
/// </summary>
/// <param name="mensagem">Mensagem a ser exibida.</param>
/// <param name="colorTexto">Cor utilizada para exibir a mensagem.</param>
static void ExibirMensagemTentativa(string mensagem, ConsoleColor colorTexto)
{
    Console.ForegroundColor = colorTexto;
    Console.WriteLine($"\n{mensagem}");
    Console.ForegroundColor = ConsoleColor.Green;
}