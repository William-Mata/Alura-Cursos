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
    private string? _comando;

    public Help(string? comando)
    {
        _comando = comando;
        _docs =  DocumentcaoSistema.ToDictionary(Assembly.GetExecutingAssembly());
    }

    public Task<Result> ExecutarAsync()
    {
        try 
        {
            return this.ExibirHelp();
        }
        catch (Exception exception)
        {
            return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(exception)));
        }
    }

    private Task<Result> ExibirHelp()
    {
        List<string> docs = new();
        docs.Add("Lista de Comandos");

        if (_comando == null)
        {
            docs.Add("adopet help <parametro> ous simplemente adopet help comando que exibe informações de ajuda dos comandos.");
            docs.Add("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            docs.Add("Realiza a importação em lote de um arquivos de pets.");
            docs.Add("Comando possíveis: ");
            docs.AddRange(_docs.Values.Select(x => x.Documentacao));
            
        }
        else if (_comando != null)
        {
            if (_docs.ContainsKey(_comando))
            {
                docs.Add(_docs[_comando].Documentacao);
            }
            else
            {
                docs.Add("Não foi encontrado uma documentação para o comando informado.");
            }
        }

        return Task.FromResult(Result.Ok().WithSuccess(new SucessDocs(docs)));
    }
}
