using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class MenuExibirMediaAvaliacaoBanda : Menu 
{
    private MenuOpcoes menuOpcoes = new();

    public override void Executar()
    {
        base.Executar();

        if (menuOpcoes.ValidarOpcao())
        {
            Banda banda;

            do
            {
                FormatarTitulo("# Exibir Média da Banda #");
                Banda.ListarBandas(bandas);

                Console.Write("\nInforme o nome da banda que deseja ver a média de avalição: ");
                string nomeBanda = Console.ReadLine()!;
                banda = bandas.ToList().Where(x => x.Nome.ToUpper() == nomeBanda.ToUpper()).FirstOrDefault();

                if (banda != null)
                {
                    Console.WriteLine($"A média de avaliação da banda {banda.Nome} é: {banda.CalcularMedia()}\n");

                    menuOpcoes.VoltarAoMenuDeOpcoes();
                }
                else
                {
                    Console.WriteLine($"A banda \"{nomeBanda}\" não foi encontrada, repita o procedimento com a banda que já foi cadastrada.\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (banda == null);
        }
    }

}
