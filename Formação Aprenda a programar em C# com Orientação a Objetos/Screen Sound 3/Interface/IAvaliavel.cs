using Screen_Sound_3.Models;

namespace Screen_Sound_3.Interface
{
    internal interface IAvaliavel
    {
        public  List<Avaliacao> Avaliacoes { get; }

        public void AdicionarNota(string nota);

        public float CalcularMedia();
    }
}
