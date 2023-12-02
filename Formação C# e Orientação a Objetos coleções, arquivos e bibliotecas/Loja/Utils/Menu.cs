using Loja.Models;
using Models;

namespace Utils;

public class Menu
{
    private static List<Produto> _produtos { get; } = new List<Produto>();  

    public static void ExibirMenu()
    {
        var opcao = "0";

        do
        {
            Console.WriteLine("################ MENU ################");
            Console.WriteLine("#######  1 - Cadastrar Produto #######");
            Console.WriteLine("#######  2 - Listar Produtos   #######");
            Console.WriteLine("#######  3 - Consultar Produto #######");
            Console.WriteLine("#######  4 - Vender Produto    #######");
            Console.WriteLine("#######  5 - Alterar Produto   #######");
            Console.WriteLine("#######  6 - Remover Produto   #######");
            Console.WriteLine("#######  7 - Saldo Caixa       #######");
            Console.WriteLine("#######  8 - Sair do Sistema   #######");
            Console.WriteLine(new string('#', 38));
            Console.Write("\nDigite a opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": _produtos.Add(Produto.CadastrarProduto()); break; 
                case "2": Produto.ListarProdutos(_produtos); break;
                case "3": Produto.ConsultarProduto(_produtos); break;
                case "4": Produto.VenderProduto(_produtos); break;
                case "5": Produto.AlterarProduto(_produtos); break;
                case "6": Produto.RemoverProduto(_produtos); break;
                case "7": Caixa.ExibirInformacao(); break;
                case "8": EncerrarSistema(); break;
                default: Console.WriteLine("\nOpção Inválida."); break;
            }

        }while(opcao != "8");

    }

    public static void VoltarAoMenu()
    {
        Console.Write("\nPressione uma tecla para voltar ao menu: ");
        Console.ReadKey();
        Console.Clear();
    }

    public static void EncerrarSistema()
    {
        Console.Clear();
        Console.WriteLine("O programa foi encerrado.");
    }
}
