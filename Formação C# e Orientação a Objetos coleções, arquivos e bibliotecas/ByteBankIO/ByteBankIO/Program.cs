using System.Text;

var enderecoArquivo = "../../../../Arquivos/contas.txt"; // CAMINHO DO ARQUIVO
//var enderecoArquivo = "../../../../Arquivos/texto2.txt"; // CAMINHO DO ARQUIVO

var fluxoDoArquivo = File.Exists(enderecoArquivo) ? new FileStream(enderecoArquivo, FileMode.Open) : null; // PEGANDO UM ARQUIVO E DIZENDO QUAL OPERAÇÃO SERÁ APLICADA A ESSE ARQUIVO
var buffer = new byte[1024]; // 1KB - ONDE SERÁ ARMAZENADO OS BYTES DO ARQUIVO
var numeroByte = 0;
var utf8 = new UTF8Encoding(); // CRIA UMA INSTANCIA DO UTF8 QUE POSSIBILITA A CONVERSÃO DO BYTE PARA O TEXTO ORIGINAL DO ARQUIVO

if(fluxoDoArquivo != null)
{
    ExibirBuffer();
}

void ExibirBuffer()
{
    while (fluxoDoArquivo.Length > numeroByte)
    {
        numeroByte += fluxoDoArquivo.Read(buffer, 0, 1024); // PEGA OS BYTES E ARMAZENA DENTRO DO ARRAY DE BYTES 
        Console.Write($"{Encoding.UTF8.GetString(buffer)}"); /// PEGA O ARRAY DE BYTES E CONVERTE NO TEXTO ORIGINAL
    }
}

#region ENUM
//Console.WriteLine(Cores.Azul == (Cores)0); // escreve True
//Console.WriteLine(Cores.Vermelho == (Cores)1); // escreve True
//Console.WriteLine(Cores.Verde == (Cores)2); // escreve True
#endregion