using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class MenuAvaliarBanda : Menu
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
                FormatarTitulo("# Avaliar Banda #");
                Banda.ListarBandas(bandas);

                Console.Write("\nInforme o nome da banda que deseja realizar a avalição: ");
                string nomeBanda = Console.ReadLine()!;
                banda = bandas.FirstOrDefault(x => x.Nome.ToUpper() == nomeBanda.ToUpper());

                if (banda != null)
                {
                    Console.Write($"Digite a sua avaliação a banda {banda.Nome}: ");
                    var avaliacaoBanda = Console.ReadLine()!;

                    if (float.TryParse(avaliacaoBanda, out _))
                    {
                        Avaliacao avaliacao = Avaliacao.Parse(avaliacaoBanda);
                        banda.Avaliacoes.Add(avaliacao);
                        Console.WriteLine($"\nA nota {avaliacaoBanda} foi atribuida a banda {nomeBanda}");
                    }

                    menuOpcoes.VoltarAoMenuDeOpcoes();
                }
                else
                {
                    Console.WriteLine($"A banda \"{nomeBanda}\" não foi encontrado, repita o procedimento com a banda que já foi cadastrada.\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                }

            } while (banda == null);
        }
    }
}
