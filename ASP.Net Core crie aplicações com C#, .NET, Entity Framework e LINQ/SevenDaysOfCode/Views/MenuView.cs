using SevenDaysOfCode.Controller;
using SevenDaysOfCode.Models;

namespace SevenDaysOfCode.Views;

public static class MenuView
{
    private static void MensagemBoasVindas()
    {
        Console.WriteLine(@"
            ████████╗░█████╗░███╗░░░███╗░█████╗░░██████╗░░█████╗░████████╗░█████╗░██╗░░██╗██╗
            ╚══██╔══╝██╔══██╗████╗░████║██╔══██╗██╔════╝░██╔══██╗╚══██╔══╝██╔══██╗██║░░██║██║
            ░░░██║░░░███████║██╔████╔██║███████║██║░░██╗░██║░░██║░░░██║░░░██║░░╚═╝███████║██║
            ░░░██║░░░██╔══██║██║╚██╔╝██║██╔══██║██║░░╚██╗██║░░██║░░░██║░░░██║░░██╗██╔══██║██║
            ░░░██║░░░██║░░██║██║░╚═╝░██║██║░░██║╚██████╔╝╚█████╔╝░░░██║░░░╚█████╔╝██║░░██║██║
            ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░╚═════╝░░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝╚═╝");

    }

    public async static Task MenuPrimeiroAcesso()
    {
        MensagemBoasVindas();
        Console.WriteLine($"\n\n");
        Console.Write("Qual é seu nome: ");
        MenuController.Nome = Console.ReadLine()!;
        await MenuController.Menu();
    }

    public static int ExibirOpcoesMenu()
    {
        Console.WriteLine("\n" + new string('#', 30));
        Console.WriteLine(new string(' ', 13) + "MENU" + new string(' ', 13));
        Console.WriteLine(new string('#', 30));
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver seus mascotes");
        Console.WriteLine("0 - Sair do jogo");
        Console.Write($"{MenuController.Nome} o que deseja fazer: ");
        return int.Parse(Console.ReadLine()!);
    }

    public static int ExibirSubMenuAdocao(Mascote mascote, string nome)
    {
        Console.WriteLine($"\n1 - Saber mais sobre o {mascote.Nome}.");
        Console.WriteLine($"2 - Adotar {mascote.Nome}");
        Console.WriteLine($"0 - Voltar");
        Console.Write($"{nome} o que deseja fazer: ");
        return int.Parse(Console.ReadLine()!);
    }

    public static int ExibirSubMenuMascoteAdotado(Mascote mascote, string nome)
    {
        Console.WriteLine("\n0 - Volta ao menu");
        Console.WriteLine($"\n1 - Saber mais sobre o {mascote.Nome}.");
        Console.WriteLine($"2 - Brincar com o {mascote.Nome}");
        Console.WriteLine($"3 - Alimentar o {mascote.Nome}");
        Console.WriteLine($"4 - Colocar o {mascote.Nome} para descansar");
        Console.Write($"{nome} o que deseja fazer: ");
        return int.Parse(Console.ReadLine()!);
    }

    public static string ExibirQuestionarioEspecie(string nome)
    {
        Console.Write($"\n{nome} Escolha uma espécie: ");
        return Console.ReadLine()!;
    }

    public static void ExibirMensagemAdocao(string nome)
    {
        Console.WriteLine($"\n\n{nome} Mascote adotado com sucesso, o ovo está chocando: \n\n");
        Console.WriteLine(@"  
                                           .--.
                                          /    \
                                         |      |
                                         \      /
                                          '----'");
    }

    public static void ExibirMensagemEncerramento()
    {
        Console.WriteLine("Jogo encerrado.");
    }  
   
    public static void ExibirMensagemOpcaoInvalida()
    {
        Console.WriteLine("Opção inválida.");
    } 
    
    public static void ExibirMensagemMascoteNaoEncontrado()
    {
        Console.WriteLine("Mascote não encontrado, pressione uma tecla para volta.");
        Console.Read();
    }
}
