using Desafio_Podcast.Models;

Podcast podcast = new Podcast("Hipsters", "Steve Jobs");

Convidado convidado = new Convidado("William");
Convidado convidado2 = new Convidado("Maria");

Episodio episodio = new Episodio(2, ".NET Orientação a Objetos", 68.7f);
episodio.Convidados.Add(convidado);
episodio.Convidados.Add(convidado2);

Episodio episodio2 = new Episodio(1, ".NET Avançando Sobre o Assunto", 57.7f);
episodio2.Convidados.Add(convidado);
episodio2.Convidados.Add(convidado2);

podcast.Episodios.Add(episodio);
podcast.Episodios.Add(episodio2);

podcast.ExibirDetalhes();