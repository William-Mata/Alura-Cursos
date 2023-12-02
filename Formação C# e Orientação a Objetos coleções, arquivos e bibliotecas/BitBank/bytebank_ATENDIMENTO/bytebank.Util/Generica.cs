namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class Generica<T>
    {
        public T PropriedadeGenerica { get; set; }

        public void ExibirInformacao(T informacao)
        {
            Console.WriteLine($"Exibindo informação: {informacao}");
            Console.WriteLine($"Exibindo tipo de informação: {informacao!.GetType()}");
            PropriedadeGenerica = informacao;
        }
    }
}
