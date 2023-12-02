using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util;

public class ListaDeContasCorrentes
{
    private ContaCorrente[] _contasCorrentes = null;
    private static int _proximaPosicao = 0;
    public int QuantidadeContas => _proximaPosicao;

    /**
        A PALAVRA THIS = CLASS DIZ QUE AO ACESSA ELA PASSANDO O INDICE DEVE RETORNA UM OBJETO ContaCorrente DO ARRAY NA POSIÇÃO INFORMADA NO INDICE

        INDEXADOR DE CLASS, DESSA FORMA CONSIGO ACESSAR O ARRAY _contasCorrentes COMO SE A CLASS ListaDeContasCorrentes FOSSE O PRÓPRIO ARRAY 
        EXEMPLO:
                SEM INDEXADOR: ListaDeContasCorrentes.RecuperarContaCorrentePorIndice[INDICE]; ATRÁVES DO MTODO
                COM INDEXADOR: ListaDeContasCorrentes[INDICE]; 
    **/

    public ContaCorrente this[int indice]   
    { 
        get 
        {
            return _contasCorrentes[indice];
        } 
    }

    public ListaDeContasCorrentes(int tamanhoArray = 5)
    {
        _contasCorrentes = new ContaCorrente[tamanhoArray];
    }

    public void Adicionar(ContaCorrente contaCorrente)
    {
        VerificarAdicaoDeConta();
        Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
        _contasCorrentes[_proximaPosicao] = contaCorrente;
        _proximaPosicao++;
    }

    public void Remover(ContaCorrente contaCorrente)
    {
        var index = Array.IndexOf(_contasCorrentes, contaCorrente);

        _contasCorrentes[index] = null;

        foreach (var item in _contasCorrentes)
        {
            if (Array.IndexOf(_contasCorrentes, item) > index)
            {
                _contasCorrentes[index] = item;
                index++;
            }
        }

        _contasCorrentes[index] = null;

        Console.WriteLine("A conta foi removida com sucesso!");
    }

    private void VerificarAdicaoDeConta()
    {
        if(_contasCorrentes.Length <= _proximaPosicao)
        {
            Console.WriteLine("Aumentando a capacidade do array.");

            ContaCorrente[] novoArray = new ContaCorrente[_proximaPosicao+1];
            _contasCorrentes.CopyTo(novoArray, 0);
            _contasCorrentes = novoArray;

        }
    }

    public void ExibirContaComMaiorSaldo()
    {
        ContaCorrente? contaMaiorSaldo = null;

        foreach(var item in _contasCorrentes)
        {
            contaMaiorSaldo = contaMaiorSaldo == null || item.Saldo > contaMaiorSaldo.Saldo ? item : contaMaiorSaldo;
        }

        Console.WriteLine($"A conta com maior saldo é a de agencia {contaMaiorSaldo.Numero_agencia} com o saldo de: {contaMaiorSaldo.Saldo.ToString("C")}");
    }

    public void ExibirListasDeContas()
    {
        Console.WriteLine();
        foreach(var item in _contasCorrentes)
        {
            Console.WriteLine(item);
        }  
    }

    public ContaCorrente RecuperarContaCorrentePorIndice(int indice)
    {
        Console.WriteLine("Recuperando Conta Por Indice");

        if (indice < 0 || indice > (_contasCorrentes.Length - 1))
        {
            throw new ArgumentOutOfRangeException("Indice informado não existe no array.");
        }

        return _contasCorrentes[indice];
    }

}
