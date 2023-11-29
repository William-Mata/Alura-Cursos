using OpenAI_API.Chat;

namespace Screen_Sound_3.Menus;

public class MenuOpcoes : Menu
{
    #region Atributos/Propriedades
    private static Dictionary<int, Menu> opcoes = new();
    #endregion

    #region Métodos/Construtores
    public MenuOpcoes(Dictionary<int, Menu> opcoesMenu) 
    { 
        opcoes = opcoesMenu;
    }

    private static void ExibirMensagemDeBoasVindas()
    {
        Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║╚═╝
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝██╗
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░╚═╝");
        string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound!";
        Console.WriteLine(mensagemDeBoasVindas);
    }

    public MenuOpcoes(){}

    public void ExibirOpcoesDoMenu()
    {
        Console.Clear();
        ExibirMensagemDeBoasVindas();

        Console.WriteLine("\nDigite 0 para sair");
        Console.WriteLine("Digite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para registrar um álbum");
        Console.WriteLine("Digite 3 para avaliar uma banda");
        Console.WriteLine("Digite 4 para avaliar um álbum");
        Console.WriteLine("Digite 5 para exibir todas as bandas");
        Console.WriteLine("Digite 6 para exibir a média de uma banda");
        Console.WriteLine("Digite 7 para ver informações de uma banda");
        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;

        if (int.TryParse(opcaoEscolhida, out _) && opcoes.ContainsKey(int.Parse(opcaoEscolhida)))
        {
            Menu menu = opcoes[int.Parse(opcaoEscolhida)];
            menu.Executar();
        }
        else
        {
            Console.WriteLine("Opção Inválida.");
            VoltarAoMenuDeOpcoes();
        }
    }

    public void VoltarAoMenuDeOpcoes()
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu:");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }

    public bool ValidarOpcao()
    {
        if (bandas.Count > 0)
        {
            return true;
        }
        else 
        {
            Console.WriteLine("Nenhuma banda foi cadastrada ainda.");
            VoltarAoMenuDeOpcoes();
            return false; 
        }
    }
    #endregion
}