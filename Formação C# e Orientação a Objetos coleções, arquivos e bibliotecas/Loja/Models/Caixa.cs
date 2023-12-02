using Utils;

namespace Loja.Models;

public static class Caixa
{
    private static decimal _saldo;
    public static decimal Valor
    {
        get
        {
            return _saldo;
        }
        set
        {
            if (value != 0 || decimal.IsPositive(value))
            {
                _saldo += value;
            }
            else
            {
                Console.WriteLine("O valor informado deve ser positivo");
            }
        }
    }

    public static void ExibirInformacao()
    {
        Console.Clear();
        Console.WriteLine($"########## CAIXA ##########");
        Console.WriteLine($"Saldo: {Valor}");
        Menu.VoltarAoMenu();
    }
}

