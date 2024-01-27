using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Utils;
using FluentResults;
using System;
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

    public Task<Result> ExecutarAsync(string[] args)
    {
        try 
        {
            return this.ExibirHelp(args);
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(exception)));
        }
    }

    private Task<Result> ExibirHelp(string[] comandoHelpASerExibido)
    {
        List<string> docs = new();
        docs.Add("Lista de Comandos");

        if (comandoHelpASerExibido.Length == 1)
        {
            docs.Add("adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.");
            docs.Add("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            docs.Add("Realiza a importação em lote de um arquivos de pets.");
            docs.Add("Comando possíveis: ");
            docs.AddRange(_docs.Values.Select(x => x.Documentacao));
            
        }
        else if (comandoHelpASerExibido.Length == 2)
        {
            string comandoHelp = comandoHelpASerExibido[1];

            if (_docs.ContainsKey(comandoHelp))
            {
                docs.Add(_docs[comandoHelp].Documentacao);
            }
            else
            {
                docs.Add("Não foi encontrado uma documentação para o comando informado.");
            }
        }

        return Task.FromResult(Result.Ok().WithSuccess(new SucessDocs(docs)));
    }
}
