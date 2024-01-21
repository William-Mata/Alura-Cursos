using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.Util;

public class Arquivo
{
    private string _caminhoDoArquivoDeImportacao;
    private List<Pet> _listaDePet;

    public Arquivo(string caminhoDoArquivoDeImportacao)
    {
        _caminhoDoArquivoDeImportacao = caminhoDoArquivoDeImportacao;
        _listaDePet = new List<Pet>();
    }

    public virtual IEnumerable<Pet> LeitorConteudoArquivoPets()
    {
        if (File.Exists(_caminhoDoArquivoDeImportacao))
        {
            using (StreamReader linhaDePropriedadesSeparadasPorVirgulas = new StreamReader(_caminhoDoArquivoDeImportacao))
            {
                while (!linhaDePropriedadesSeparadasPorVirgulas.EndOfStream)
                {
                    var stringPropriedadesPet = linhaDePropriedadesSeparadasPorVirgulas.ReadLine()!;
                    var pet = ExtrairPetPorLinha(stringPropriedadesPet);

                    _listaDePet.Add(pet);
                }
            }

            return _listaDePet;
        }
        else
        {
            throw new Exception("Arquivo não encontrado");
        }
    }

    public Pet ExtrairPetPorLinha(string linha)
    {
        if (string.IsNullOrEmpty(linha))
        {
            throw new ArgumentNullException("linha vazia ou null");
        }

        string[] propriedades = linha!.Split(';');
         
        if (propriedades.Length != 3)
        {
            throw new ArgumentOutOfRangeException("Uma ou mais propriedades estão faltando.");
        }

        if (!Guid.TryParse(propriedades[0], null, out _))
        {
            throw new ArgumentException("Guid Inválido.");
        }

        if (!int.TryParse(propriedades[2], out _) || (int.Parse(propriedades[2]) < 0 || int.Parse(propriedades[2]) > 1))
        {
            throw new ArgumentException("Tipo de Pet Inválido.");
        }

        Pet pet = new Pet(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            tipo: (TipoPet)int.Parse(propriedades[2])
            );

        return pet;
    }
}
