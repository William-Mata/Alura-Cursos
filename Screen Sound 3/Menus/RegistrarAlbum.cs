using Screen_Sound_3.Models;

namespace Screen_Sound_3.Menus;

public class RegistrarAlbum : Menu
{
    private MenuOpcoes menuOpcoes = new();
    private MenuExibirDetalhes menuExibirDetalhes = new();
    private RegistroDeMusica registroDeMusica = new();

    public override void Executar()
    {
        base.Executar();

        if (menuOpcoes.ValidarOpcao())
        {
            Banda banda;

            do
            {
                FormatarTitulo("# Registro de Álbum #");
                Banda.ListarBandas(bandas);

                Console.Write("\nInforme o nome da banda que deseja registrar o álbum: ");
                string nomeBanda = Console.ReadLine()!;
                banda = bandas.Where(x => x.Nome.ToUpper() == nomeBanda.ToUpper()).FirstOrDefault();

                if (banda != null)
                {
                    Console.Write($"Digite o nome do Álbum: ");
                    var nomeDoAlbum = Console.ReadLine()!;

                    if (!string.IsNullOrEmpty(nomeDoAlbum))
                    {
                        List<Musica> musicas = registroDeMusica.RegistrarMusica(banda);
                        Album album = new Album(nomeDoAlbum, musicas);
                        banda.Albuns.Add(album);
                        Console.WriteLine($"\nO {Album.QuantidadeDeAlbunsCriados}° - Álbum {album.Nome} foi atribuida a banda {nomeBanda}");
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
