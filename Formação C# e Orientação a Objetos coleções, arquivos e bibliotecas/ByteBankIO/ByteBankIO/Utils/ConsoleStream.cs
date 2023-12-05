using System.Text;

namespace ByteBankIO.Utils;

public class ConsoleStream
{
    private static string _caminhoArquivos = "../../../../Arquivos/"; // CAMINHO DO ARQUIVO

    public static void StreamDeEntradaConsole()
    {
        using (var streamEntrada = Console.OpenStandardInput()) // CRIAR UMA INSTANCIA DE LEITURA DO QUE O USUARIO DIGITA NO CONSOLE
        {
            using(var arquivo = new FileStream(_caminhoArquivos + "ConsoleEntrada.txt", FileMode.Create)) // CRIA UM NOVO ARQUIVO
            {
                using(var streamWrite = new StreamWriter(arquivo)) // ESCREVER DENTRO DO ARQUIVO
                {
                    var buffer = new byte[1024]; //1KB
                    var bytesLidos = 1;

                    while (bytesLidos > 0) {
                        bytesLidos = streamEntrada.Read(buffer, 0, 1024); // PEGA O QUE FOI ESCRITO PELO USUARIO E ARMAZENA NO ARRAY BUFFER
                        Console.WriteLine($"Bytes lidos no console: {bytesLidos}");
                        streamWrite.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesLidos)); // PASSA O QUE FOI ARMAZENADO NO ARRAY PARA DENTRO DO ARQUIVO
                        streamWrite.Flush(); // ATUALIZA O ARQUIVO COM AS FUNÇÕES REALIZADA ATÉ O MOMENTO
                    }
                }
            }
        }
    }
}
