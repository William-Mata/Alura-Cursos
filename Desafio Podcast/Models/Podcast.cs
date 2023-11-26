namespace Desafio_Podcast.Models
{
    class Podcast
    {
        #region Propriedades
        public string Nome { get; }
        public string Host { get;}
        public int TotalEpisodios => Episodios.Count();
        public List<Episodio> Episodios { get; set; } = new List<Episodio>();
        #endregion

        #region Métodos
        public Podcast(string nome, string host)
        {
            Nome = nome;
            Host = host;
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine(new string('#', 30));
            Console.WriteLine(" Informações Sobre o Podcast ");
            Console.WriteLine(new string('#', 30));
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Host: {Host}");
            Console.WriteLine($"Total de Episodios: {TotalEpisodios}");
            Console.WriteLine($"Episodios:");
            int contador = 1;

            Episodios = Episodios.OrderBy(y => y.Ordem).ToList();
            Episodios.ForEach(episodio => {Console.WriteLine($" {contador++}- {episodio.Resumo}");});
        }
        #endregion
    }
}