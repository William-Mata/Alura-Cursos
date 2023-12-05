using ByteBankIO.Models;
using System.Text;
namespace ByteBankIO.Utils;

public static class Arquivo
{

    private static string _caminhoArquivos = "../../../../Arquivos/"; // CAMINHO DO ARQUIVO

    public static void BuscarArquivoTXT() 
    {
        var nomeArquivo = "contas.txt";

        // PEGANDO UM ARQUIVO E DIZENDO QUAL OPERAÇÃO SERÁ APLICADA A ESSE ARQUIVO
        using (var fluxoDoArquivo = new FileStream(_caminhoArquivos + nomeArquivo, FileMode.Open))  // O BLOCO USING FAZ A CHAMADA PARA O MÉTODO DISPOSE(), QUE CHAMA O CLOSE().
        {
            var buffers = new byte[1024]; // 1KB - ONDE SERÁ ARMAZENADO OS BYTES DO ARQUIVO
            var quantiadeBytes = 1;

            while (quantiadeBytes > 0)
            {
                quantiadeBytes = fluxoDoArquivo.Read(buffers, 0, 1024); // PEGA OS BYTES E ARMAZENA DENTRO DO ARRAY DE BYTES 
                ExibirBuffer(buffers, quantiadeBytes);
            }
        }

        //fluxoDoArquivo.Close(); // FECHA O ARQUIVO APÓS A UTILIZAÇÃO.
    }

    public static void ExibirBuffer(byte[] buffer, int quantiadeBytes)
    {
        var utf8 = new UTF8Encoding(); // INSTANCIA DO UTF8 PARA A CONVERSÃO DO BYTE PARA O TEXTO ORIGINAL DO ARQUIVO, ABAIXO FOI USADA A CLASS STATICA DO UTF8
        Console.Write($"{Encoding.UTF8.GetString(buffer, 0, quantiadeBytes)}"); /// PEGA O ARRAY DE BYTES E CONVERTE NO TEXTO ORIGINAL
    }

    public static void ConverterArquivoEmCliente()
    {
        var nomeArquivo = "contas.txt";
        Console.WriteLine("\n\n===================================\n");

        // PEGANDO UM ARQUIVO E DIZENDO QUAL OPERAÇÃO SERÁ APLICADA A ESSE ARQUIVO
        using (var fluxoDoArquivo = new FileStream(_caminhoArquivos + nomeArquivo, FileMode.Open))
        {
            using (var reader = new StreamReader(fluxoDoArquivo))
            {
                //Console.WriteLine(reader.ReadLine()); // ReadLine LER 1 LINHA DO ARQUIVO
                //Console.WriteLine(reader.ReadToEnd()); // ReadToEnd() LER TODO O ARQUIVO
                //Console.WriteLine(reader.Read()); // Read() LER 1 BYTE DO ARQUIVO

                while (!reader.EndOfStream) // VERIFICA SE JÁ CHEGOU A FINAL DO ARQUIVO
                {
                    var informacoesBrutaConta = reader.ReadLine();
                    string[] informacoesConta = informacoesBrutaConta!.Split(",");

                    if(informacoesConta.Length > 0)
                    {
                        ContaCorrente conta = new ContaCorrente(int.Parse(informacoesConta[0]), int.Parse(informacoesConta[1]));
                        conta.Depositar(double.Parse(informacoesConta[2].Replace(".", ",")));
                        conta.Titular.Nome = informacoesConta[3];
                        Console.WriteLine(conta);
                    }
                }
            }
        }
    }

    public static void CriarArquivo()
    {
        var nomeArquivo = "contasNovas.csv"; 
        var informacaoDoArquivo = "456, 7895, 4785.40, Gustavo Santos"; // INFORMAÇÕES QUE VÃO SER ESCRITAS NO ARQUIVO 

        using(var arquivo = new FileStream(_caminhoArquivos+nomeArquivo, FileMode.Create)) // FILEMODE.CREATE PARA CRIAR UM ARQUIVO NOVO
        {
            var bytes = Encoding.UTF8.GetBytes(informacaoDoArquivo); // PEGANDO OS BYTES 
            arquivo.Write(bytes, 0, bytes.Length); // ESCREVENDO AS INFORMAÇÕES NO ARQUIVO
        }
    }

    public static void CriarArquivoWriter()
    {
        var nomeArquivo = "contasNovas3.txt";
        var informacaoDoArquivo = "456, 7895, 4785.40, Gustavo Santos"; // INFORMAÇÕES QUE VÃO SER ESCRITAS NO ARQUIVO 

        // FILEMODE.CREATE PARA CRIAR UM ARQUIVO NOVO CASO EXISTA SERÁ SOBRESCRITO 
        // FILEMODE.CREATENEW SERVER PARA CRIAÇÃO DE ARQUIVOS NOVOS, NÃO SOBRESCREVE ARQUIVO EXISTENTE E GERAR EXECPTION
        using (var arquivo = new FileStream(_caminhoArquivos + nomeArquivo, FileMode.Create))
        {
            using(var stream = new StreamWriter(arquivo, Encoding.UTF8)) // UTILIZANDO O STREAMWRITER PARA ESCREVER NO ARQUIVO
            {
                stream.WriteLine(informacaoDoArquivo);
                stream.Flush(); // O FLUSH ATUALIZA O ARQUIVO COM AS AÇÕES QUE FORAM EXECUTADAS ATÉ O MOMENTO DE SUA CHAMADA
                stream.WriteLine(informacaoDoArquivo);
                stream.WriteLine(informacaoDoArquivo);

            }
        }
    }

    public static void CriarArquivoBinario()
    {
        var nomeArquivo = "arquivoBinario.txt";
        var informacaoDoArquivo = "456, 7895, 4785.40, Gustavo Santos"; 

        using (var arquivo = new FileStream(_caminhoArquivos + nomeArquivo, FileMode.Create))
        {
            using (var stream = new BinaryWriter(arquivo)) // UTILIZANDO O BINARYWRITER PARA ESCREVER NO ARQUIVO
            {
                stream.Write(informacaoDoArquivo);
                stream.Write(true);
                stream.Write(false);
                stream.Write(1232548);
                stream.Write(10.05d);
                stream.Flush(); 
            }
        }
    }

    public static void LerArquivoBinario()
    {
        var nomeArquivo = "arquivoBinario.txt";

        using (var arquivo = new FileStream(_caminhoArquivos + nomeArquivo, FileMode.Open))
        {
            using (var stream = new BinaryReader(arquivo)) // UTILIZANDO O BINARYREAD PARA LER O ARQUIVO BINARY
            {
                Console.WriteLine(stream.ReadString()); // LER O BINARIO PARA STRING;
                Console.WriteLine(stream.ReadBoolean()); // LER O BINARIO PARA BOOLEAN;
                Console.WriteLine(stream.ReadBoolean()); // LER O BINARIO PARA BOOLEAN;
                Console.WriteLine(stream.ReadInt32());// LER O BINARIO PARA INTEIRO;
                Console.WriteLine(stream.ReadDouble());// LER O BINARIO PARA DOUBLE;
            }
        }
    }

    public static void ManipulandoComFile()
    {
        var nomeArquivo = "contas.txt";
        var linhas = File.ReadAllLines(_caminhoArquivos+ nomeArquivo); // LER TODAS AS LINHAS DO ARQUIVO
        Console.WriteLine($"Quantidade de Linhas: {linhas.Length}"); // EXIBE A QUANTIDADE DE LINHAS QUE O ARQUIVO TEM

        var bytesArquivo = File.ReadAllBytes(_caminhoArquivos + nomeArquivo); // LER TODAS AS LINHAS DO ARQUIVO
        Console.WriteLine($"Quantidade de Bytes: {bytesArquivo.Length}"); // EXIBE O TAMANHO DE BYTES DO ARQUIVO

        File.WriteAllText(_caminhoArquivos + "fileTeste.txt", $"Quantidade de Bytes: {bytesArquivo.Length}"); // CRIA UM ARQUIVO COM O TEXTO
        File.WriteAllBytes(_caminhoArquivos + "fileTeste2.txt", bytesArquivo); // CRIA UM ARQUIVO COM OS BYTES

        foreach (var item in linhas)
        {
            Console.WriteLine(item);
        }
    }
}
