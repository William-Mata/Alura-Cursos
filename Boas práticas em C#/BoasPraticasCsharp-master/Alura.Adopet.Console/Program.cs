using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.UI;
using FluentResults;

IComando? comando = FabricaComando.FabricarComando(args);

if (comando != null)
{
    var result = await comando.ExecutarAsync(); 
    ConsoleUI.ExibirResultado(result);
}
else
{
    ConsoleUI.ExibirResultado(Result.Fail("Comando inválido!"));
}
