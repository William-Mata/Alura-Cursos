using Alura.Adopet.Console.Utils;
using FluentResults;

namespace Alura.Adopet.Console.UI;

public static class ConsoleUI
{

    public static void ExibirResultado(Result result)
    {
        try
        {
            System.Console.ForegroundColor = ConsoleColor.Green;

            if (result.IsFailed)
            {
                ExibirFalha(result);
            }
            else
            {
                ExibirSucesso(result);
            }
        }
        finally
        {
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private static void ExibirSucesso(Result result)
    {
        var sucess = result.Successes.First();

        switch (sucess)
        {
            case SucessPets s:
                ExibirPets(s);
                break;
            case SucessDocs h:
                ExibirHelp(h);
                break;
        }
    }

    private static void ExibirHelp(SucessDocs sucess)
    {
        foreach (var doc in sucess.Documentacao)
        {
            System.Console.WriteLine(doc);
        }
    }

    private static void ExibirPets(SucessPets sucess)
    {
        foreach(var pet in sucess.Data)
        {
            System.Console.WriteLine(pet);
        }

        System.Console.WriteLine(sucess.Message);
    }

    private static void ExibirFalha(Result result)
    {
        var erro = result.Errors.FirstOrDefault();
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"Aconteceu um exceção: {erro!.Message}");
    }
}
