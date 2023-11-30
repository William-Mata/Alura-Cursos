namespace Screen_Sound_2.Models
{
    class Album
    {
        #region Atributos/Propriedades
        public string Nome { get; set; }
        public float Duracao => Musicas.Sum(x => x.Duracao);
        public List<Musica> Musicas { get; set; } = new List<Musica>();
        #endregion

        #region Métodos
        public Album(Musica musica)
        {
            this.Musicas = new List<Musica>() { musica };
        }

        public void ExibirInformacoesDoAlbum()
        {
            Console.WriteLine($"        Nome: {Nome}");
            Console.WriteLine($"        Duração: {Duracao}");
            Console.WriteLine($"        Músicas: ");

            int contador = 1;
            Musicas.ForEach(x => Console.WriteLine($"                {contador++} - {x.Nome}"));
            Console.WriteLine();
        }
        #endregion
    }
}
