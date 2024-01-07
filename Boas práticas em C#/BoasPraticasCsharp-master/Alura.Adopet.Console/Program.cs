using Alura.Adopet.Console.Menu;

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comandosASerExecutado = args[0].Trim();

    switch (comandosASerExecutado)
    {
        case "import":
            Import importa = new Import();
            await importa.ImportacaoDeArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
            break;
        case "help":
            var comandoHelpASerExibido = args;
            new Help().ExibirHelp(comandoHelpASerExibido);
            break;
        case "show":
            var caminhoDoArquivoASerLido = Path.GetFullPath($"lista.csv");
            Show.ListarPetsArquivo(caminhoDoArquivoASerLido);
            break;
        case "list":
            await ListPets.ListarPetsAsync();
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}