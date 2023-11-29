using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class MenuExibirTodasBandas : Menu 
{
    private MenuOpcoes menuOpcoes = new();

    public override void Executar()
    {
        base.Executar();

        if (menuOpcoes.ValidarOpcao())
        {
            FormatarTitulo("# Exibir Todas as Bandas #");
            var posicao = 1;
            bandas.ForEach(x => Console.WriteLine((posicao++) + " - " + x.Nome));
            menuOpcoes.VoltarAoMenuDeOpcoes();
        }
    }
}
