using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class MenuExibirDetalhes : Menu 
{
    private MenuOpcoes menuOpcoes = new();

    public override void Executar()
    {
        base.Executar();

        if (menuOpcoes.ValidarOpcao())
        {
            FormatarTitulo("# Exibir Informações da Banda #");

            Banda.ListarBandas(bandas);
            Console.Write("\nInforme o nome da banda que deseja visualizar detalhes: ");
            string nomeBanda = Console.ReadLine()!;
            var banda = bandas.Where(x => x.Nome.ToUpper() == nomeBanda.ToUpper()).FirstOrDefault();

            if (banda != null)
            {
                banda.ExibirInformacoesDaBanda();
            }
            else
            {
                Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
            }

            menuOpcoes.VoltarAoMenuDeOpcoes();
        }
    }

}
