using SevenDaysOfCode.Controllers;
using SevenDaysOfCode.Models;
using SevenDaysOfCode.Views;

namespace SevenDaysOfCode.Controller;

public static class MenuController
{
    private static int opcao = 1;
    public static string Nome { get; set; }
    public static List<Mascote> Mascotes {get; set;} = new List<Mascote>();

    public static async Task Menu()
    {
        do
        {
            var opcao  = MenuView.ExibirOpcoesMenu();

            switch (opcao)
            {
                case 0: MenuView.ExibirMensagemEncerramento(); break;
                case 1: await MascoteController.ListarMascotes(); break;
                case 2: MascoteController.ListarMascotesAdotados(Mascotes); break;
                default: MenuView.ExibirMensagemOpcaoInvalida(); break;
            }

        }while(opcao > 0);
    }

    public static async Task ExibirSubMenuAdocao()
    {
        var opcaoAdocao = 1;
        var nome = MenuView.ExibirQuestionarioEspecie(Nome);
        var mascote = await MascoteController.ConsultarMascotePorNome(nome);

        if (mascote == null)
        {
            MenuView.ExibirMensagemMascoteNaoEncontrado();
            await MascoteController.ListarMascotes();
        }
        else
        {
            while (opcaoAdocao > 0)
            {
                opcaoAdocao = MenuView.ExibirSubMenuAdocao(mascote, Nome);

                switch (opcaoAdocao)
                {
                    case 0: break;
                    case 1: MascoteController.InformacoesMascote(mascote); break;
                    case 2: 
                        Mascotes.Add(mascote);
                        MenuView.ExibirMensagemAdocao(Nome);
                        opcaoAdocao = 0;
                    break;
                    default: MenuView.ExibirMensagemOpcaoInvalida(); break;
                }
            };
        }
    }

    public static void ExibirSubMenuMascoteAdotado()
    {
        var opcaoMascote = 1;
        var nome = MenuView.ExibirQuestionarioEspecie(Nome);
        var mascote = Mascotes.FirstOrDefault(x => x.Nome == nome);

        if (mascote == null)
        {
            MenuView.ExibirMensagemMascoteNaoEncontrado();
            MascoteController.ListarMascotesAdotados(Mascotes);
        }
        else
        {
            do{
                opcaoMascote = MenuView.ExibirSubMenuMascoteAdotado(mascote, Nome);

                switch (opcaoMascote)
                {
                    case 0: break;
                    case 1: MascoteController.InformacoesMascote(mascote); break;
                    case 2: mascote.Brincar(); break;
                    case 3: mascote.Alimentar(); break;
                    case 4: mascote.Descansar(); break;
                    default: MenuView.ExibirMensagemOpcaoInvalida(); break;
                }

            } while (opcaoMascote > 0) ;
        }
    }
}
