﻿using Alura.Adopet.Console.Util;
using System.Reflection;
using System.Reflection.Metadata;

namespace Alura.Adopet.Console.Menu;

[DocComando("help", " adopet help < parametro > ou simplemente adopet help comando que exibe informações de ajuda dos comandos.")]
public class Help
{
    private Dictionary<string, DocComando> _docs;

    public Help()
    {
        _docs = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttributes<DocComando>().Any())
            .Select(t => t.GetCustomAttribute<DocComando>()!)
            .ToDictionary(d => d.Instrucao);
    }

    public void ExibirHelp(string[] comandoHelpASerExibido)
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
