using Screen_Sound_2.Models;

List<Banda> bandas = new List<Banda>();

Banda banda = new Banda("Charlie Brown Jr");
Banda banda2 = new Banda("O Rappa");

Musica musica = new Musica(banda);
musica.Nome = "Pontes Indestrutiveis";
musica.Duracao = 5.27f;
musica.AnoDeLancamento = 2012;
musica.Genero.Nome = "Rock";

Musica musica2 = new Musica(banda2);
musica2.Nome = "Pescador De Ilusões";
musica2.Duracao = 6.15f;
musica2.AnoDeLancamento = 2013;
musica2.Disponivel = true;
musica2.Genero.Nome = "Rock";

Musica musica3 = new Musica(banda);
musica3.Nome = "Zóio De Lula";
musica3.Duracao = 5.27f;
musica3.AnoDeLancamento = 2012;
musica3.Genero.Nome = "Rock";

Album album = new Album(musica);
album.Nome = "So as brabas";
album.Musicas.Add(musica2);

Album album2 = new Album(musica3);
album2.Nome = "Imunidade Musical";
album2.Musicas.Add(musica);


banda.Albuns.Add(album);
banda.Albuns.Add(album2);
bandas.Add(banda);

banda2.Albuns.Add(album);
bandas.Add(banda2);

bandas.ForEach(banda => banda.ExibirInformacoesDaBanda());
