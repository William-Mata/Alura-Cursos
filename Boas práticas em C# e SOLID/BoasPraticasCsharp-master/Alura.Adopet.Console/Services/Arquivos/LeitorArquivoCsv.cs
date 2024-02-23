using Alura.Adopet.Console.Services.Abstracoes;

namespace Alura.Adopet.Console.Services.Arquivos;

public abstract class LeitorArquivoCsv<T> : ILeitorArquivos<T>
{
    private string _caminhoDoArquivoDeImportacao;
    private List<T> _listaDeObjetos;

    public LeitorArquivoCsv(string caminhoDoArquivoDeImportacao)
    {
        _caminhoDoArquivoDeImportacao = caminhoDoArquivoDeImportacao;
        _listaDeObjetos = new List<T>();
    }

    public virtual IEnumerable<T> LerConteudoArquivo()
    {
        using (StreamReader linhaDePropriedadesSeparadasPorVirgulas = new StreamReader(_caminhoDoArquivoDeImportacao))
        {
            while (!linhaDePropriedadesSeparadasPorVirgulas.EndOfStream)
            {
                var stringPropriedades = linhaDePropriedadesSeparadasPorVirgulas.ReadLine()!;
                var objeto = ExtrairPorLinha(stringPropriedades);

                _listaDeObjetos.Add(objeto);
            }
        }

        return _listaDeObjetos;
    }

    public abstract T ExtrairPorLinha(string linha);

   
}
