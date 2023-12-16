using SevenDaysOfCode.Client;
using SevenDaysOfCode.Controller;
using SevenDaysOfCode.Models;
using SevenDaysOfCode.Views;

namespace SevenDaysOfCode.Controllers;

public class MascoteController
{
    public async static Task ListarMascotes()
    {
        var list = await PokeApi.ListarMascoteApiAsync(); ;
        MascoteView.ExibirListaMascotes(list);
        await MenuController.ExibirSubMenuAdocao();
    }

    public static void ListarMascotesAdotados(List<Mascote> mascotes)
    {
        MascoteView.ExibirMascotesAdotados(mascotes);
        MenuController.ExibirSubMenuMascoteAdotado();
    }

    public static async Task<Mascote> ConsultarMascotePorNome(string nome)
    {
        return await PokeApi.ConsultarMascotePorNomeAsync(nome);
    }

    public static void InformacoesMascote(Mascote mascote)
    {
        MascoteView.ExibirInforamcoesMascote(mascote);
    }

}
