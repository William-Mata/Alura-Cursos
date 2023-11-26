namespace Desafio_Podcast.Models
{
    class Episodio
    {
        #region Propriedades
        public int Ordem { get; }
        public string Titulo { get;}
        public float Duracao { get; }
        public string Resumo => $"O Episodio \"{Titulo}\" com participação do(s) convidado(s) {string.Join(", " , Convidados.Select(x=> x.Nome))}  tem duração de {Duracao}.";
        public List<Convidado> Convidados { get; set; } = new();
        #endregion

        #region Métodos
        public Episodio(int ordem, string titulo, float duracao)
        {
            Ordem = ordem;
            Titulo = titulo;
            Duracao = duracao;
        }
        #endregion
    }
}
