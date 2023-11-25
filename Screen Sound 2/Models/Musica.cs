using System.Reflection.Metadata.Ecma335;

namespace Screen_Sound_2.Models
{
    class Musica
    {
        #region Atributos/Propriedades
        public string Nome { get; set; }
        public float Duracao { get; set; }
        public int AnoDeLancamento { get; set; }
        public bool Disponivel { get; set; }

        //public string Descricao { get { return $"A música {Nome} foi lançada no ano de {AnoDeLancamento} pelo artista {Artista} e tem duração de {Duracao}"; } }
        public string Descricao => $"A música {Nome} do gênero {Genero.Nome} foi lançada no ano de {AnoDeLancamento} pela banda {Banda.Nome} e tem duração de {Duracao}";
        public Genero Genero { get; set; } = new Genero();
        public Banda Banda { get; }
        #endregion

        #region Métodos

        public Musica(Banda banda) {
            this.Banda = banda;
        }

        public void ExibirFichaTecnica()
        {
            Console.WriteLine(new string('*', 25));
            Console.WriteLine(" Ficha Tecnica da Música");
            Console.WriteLine(new string('*', 25));
            Console.WriteLine($"Música: {Nome}");
            Console.WriteLine($"Banda: {Banda.Nome}");
            Console.WriteLine($"Duração: {Duracao}");
            Console.WriteLine($"Ano de Lançamento: {AnoDeLancamento}");
            Console.WriteLine($"Gênero: {Genero.Nome}");
            Console.WriteLine($"Descrição: {Descricao}");
            Console.WriteLine($"Disponivel: {(Disponivel ? "Sim" : "Não")}\n");
        }
        #endregion
    }
}
