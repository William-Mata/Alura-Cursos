using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class MenuAvaliarAlbum : Menu
{
    #region Atributos/Propriedades
    private MenuOpcoes menuOpcoes = new();
    #endregion

    #region Métodos/Construtores
    public override void Executar()
    {
        base.Executar();

        if (menuOpcoes.ValidarOpcao())
        {
            Banda banda;

            do
            {
                FormatarTitulo("# Avaliar Álbum #");
                Banda.ListarBandas(bandas);

                Console.Write("\nInforme o nome da banda que deseja realizar a avalição: ");
                string nomeBanda = Console.ReadLine()!;
                banda = bandas.FirstOrDefault(x => x.Nome.ToUpper() == nomeBanda.ToUpper());

                if (banda != null)
                {
                    Console.WriteLine();
                    Album.ListarTodosAlbuns(banda.Albuns.ToList());
                    Console.Write("\nInforme o nome do Álbum que deseja realizar a avalição: ");
                    string nomeAlbum = Console.ReadLine()!;
                    Album album = banda.Albuns.ToList().FirstOrDefault(x => x.Nome.ToUpper() == nomeAlbum.ToUpper());

                    if (album != null)
                    {
                        Console.Write($"Digite a sua avaliação do Álbum {nomeAlbum}: ");
                        var avaliacaoAlbum = Console.ReadLine()!;
                        album.AdicionarNota(avaliacaoAlbum);
                        Console.WriteLine($"\nA nota {avaliacaoAlbum} foi atribuida ao Album {nomeAlbum}");
                    }
                    else
                    {
                        Console.WriteLine($"O álbum \"{nomeAlbum}\" não foi encontrado.\n");
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
    #endregion
}