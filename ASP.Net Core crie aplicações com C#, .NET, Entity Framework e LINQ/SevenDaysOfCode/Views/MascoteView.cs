using SevenDaysOfCode.Dtos;
using SevenDaysOfCode.Models;

namespace SevenDaysOfCode.Views;

public class MascoteView
{
    public static void ExibirListaMascotes(ListMascoteDto listMascoteDtos)
    {
        Console.Clear();
        Console.WriteLine($"{new string('#', 30)}");
        Console.WriteLine($"{new string(' ', 7)} ADOTAR UM MASCOTE {new string(' ', 7)}");
        Console.WriteLine($"{new string('#', 30)}");
        listMascoteDtos.Mascotes.ForEach(m => Console.WriteLine($"{m.Nome}"));
    }

    public static void ExibirMascotesAdotados(List<Mascote> mascotes)
    {
        Console.Clear();
        Console.WriteLine($"{new string('#', 30)}");
        Console.WriteLine($"{new string(' ', 8)} SEUS MASCOTES {new string(' ', 8)}");
        Console.WriteLine($"{new string('#', 30)}");
        mascotes.ForEach(m => Console.WriteLine($"{m.Nome}\n"));
    }

    public static void ExibirInforamcoesMascote(Mascote mascote)
    {
        Console.WriteLine($"\n{mascote}\n");
    }
}
