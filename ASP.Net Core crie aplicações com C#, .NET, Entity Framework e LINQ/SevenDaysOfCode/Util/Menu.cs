using SevenDaysOfCode.Client;
using SevenDaysOfCode.Models;

namespace SevenDaysOfCode.Util;

public static class Menu
{
    private static int opcao = 1;
    public static string Nome { get; set; }
    public static List<Mascote> Mascotes {get; set;} = new List<Mascote>();

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

    public static async Task ExibirMenu()
    {
        MensagemBoasVindas();
        Console.WriteLine($"\n\n");

        Console.Write("Qual é seu nome: ");
        Nome = Console.ReadLine()!;

        do
        {
            Console.WriteLine("\n"+new string('#', 30));
            Console.WriteLine(new string(' ', 13) + "MENU" + new string(' ', 13));
            Console.WriteLine(new string('#', 30));
            Console.WriteLine("1 - Adotar um mascote virtual");
            Console.WriteLine("2 - Ver seus mascotes");
            Console.WriteLine("0 - Sair do jogo");
            Console.Write($"{Nome} o que deseja fazer: ");
            opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 0: Console.WriteLine("Jogo encerrado."); break;
                case 1: await Mascote.ListarMascotes(); break;
                case 2: Mascote.ListarMascotesAdotador(); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

        }while(opcao > 0);
    }

    public static async Task ExibirSubMenuAdocao()
    {
        var opcaoAdocao = 1;
        Console.Write($"\n{Nome} Escolha uma espécie: ");
        var nome = Console.ReadLine()!;
        var mascote = await PokeApi.ConsultarMascotePorNomeAsync(nome);

        if (mascote == null)
        {
            Console.WriteLine("Mascote não encontrado, pressione uma tecla para volta.");
            Console.Read();
            await Mascote.ListarMascotes();
        }
        else
        {
            while (opcaoAdocao > 0)
            {
                Console.WriteLine($"\n1 - Saber mais sobre o {mascote.Nome}.");
                Console.WriteLine($"2 - Adotar {mascote.Nome}");
                Console.WriteLine($"0 - Voltar");
                Console.Write($"{Nome} o que deseja fazer: ");
                opcaoAdocao = int.Parse(Console.ReadLine()!);

                switch (opcaoAdocao)
                {
                    case 0: break;
                    case 1: Console.WriteLine($"\n{mascote}"); break;
                    case 2: 
                        Mascotes.Add(mascote);
                        Console.WriteLine($"\n\n{Nome} Mascote adotado com sucesso, o ovo está chocando: \n\n");
                        Console.WriteLine(@"  
                                           .--.
                                          /    \
                                         |      |
                                         \      /
                                          '----'");
                        opcaoAdocao = 0;
                    break;
                    default: Console.WriteLine("Opção inválida."); break;
                }

            };
        }
    }

}
