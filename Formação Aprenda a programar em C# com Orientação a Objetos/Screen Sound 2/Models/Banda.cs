namespace Screen_Sound_2.Models
{
    class Banda
    {
        #region Atributos/Propriedades
        public string Nome { get; set; }
        public List<Album> Albuns { get; set; } = new List<Album>();
        #endregion

        #region Métodos
        public Banda(string nome)
        {
            Nome = nome;
        }

        public void ExibirInformacoesDaBanda()
        {
            Console.WriteLine(new string('#', 27));
            Console.WriteLine(" Informações Sobre a Banda");
            Console.WriteLine(new string('#', 27));
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Álbuns: ");
            int contador = 1;
            Albuns.ForEach(x => { Console.WriteLine($"        {contador++} - Álbum");  x.ExibirInformacoesDoAlbum(); });;
        }
        #endregion
    }
}
