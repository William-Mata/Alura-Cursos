using ByteBankIO.Utils;

partial class Program // PARTIAL POSSIBILITA QUE A CLASS SEJA SEPARADA EM ARQUIVOS DIFERENTES
{
    static void Main(string[] args)
    {

        Arquivo.BuscarArquivoTXT();
        Arquivo.ConverterArquivoEmCliente();
        Arquivo.CriarArquivo();
        Arquivo.CriarArquivoWriter();
        Arquivo.CriarArquivoBinario();
        Arquivo.LerArquivoBinario();
        Arquivo.ManipulandoComFile();

        ConsoleStream.StreamDeEntradaConsole();

        //ProgramaTeste(); // CHAMANDO O RESTANTE DA CLASS PROGRAM
    }
}
