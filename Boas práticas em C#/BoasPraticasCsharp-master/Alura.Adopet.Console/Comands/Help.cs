using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Utils;
using System.Reflection;

namespace Alura.Adopet.Console.Comands;

[DocComando("help", " adopet help < parametro > ou simplemente adopet help comando que exibe informações de ajuda dos comandos.")]
public class Help : IComando
{
    private Dictionary<string, DocComando> _docs;

    public Help()
    {
        _docs =  DocumentcaoSistema.ToDictionary(Assembly.GetExecutingAssembly());
    }

    public Task ExecutarAsync(string[] args)
    {
        this.ExibirHelp(args);
        return Task.CompletedTask;
    }

    private void ExibirHelp(string[] comandoHelpASerExibido)
    {
        System.Console.WriteLine("Lista de comandos.");

        if (comandoHelpASerExibido.Length == 1)
        {
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");

            foreach(var doc in _docs.Values)
            {
                System.Console.WriteLine($"{doc.Documentacao}");
            }
        }
        else if (comandoHelpASerExibido.Length == 2)
        {

            string comandoHelp = comandoHelpASerExibido[1];

            if (_docs.ContainsKey(comandoHelp))
            {
                System.Console.WriteLine(_docs[comandoHelp].Documentacao);
            }
        }
    }
}
