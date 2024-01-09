using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Comands.Interfaces;
using System.Linq;

Console.ForegroundColor = ConsoleColor.Green;

try
{
    string comandosASerExecutado = args[0].Trim();
    var comandosDoSsistema = new ComandosDoSsistema()[comandosASerExecutado];

    if (comandosDoSsistema != null)
    {
       await comandosDoSsistema.ExecutarAsync(args); 
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}