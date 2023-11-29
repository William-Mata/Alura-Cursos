using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class RegistrarBanda : Menu
{
    private MenuOpcoes menuOpcoes = new();

    public override void Executar()
    {
        base.Executar();

        FormatarTitulo("# Registro de Banda #");
        Console.Write("\nDigite o nome da banda: ");
        var nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandas.Add(banda);
        Console.WriteLine($"A banda \"{nomeDaBanda}\" foi cadastrada com sucesso!");
        menuOpcoes.VoltarAoMenuDeOpcoes();
    }
}
