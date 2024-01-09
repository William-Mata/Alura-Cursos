using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.Util;

public static class Arquivo
{
    public static IEnumerable<Pet> ExtrairConteudoArquivoPets(string caminhoDoArquivoDeImportacao)
    {
        List<Pet> listaDePet = new List<Pet>();

        using (StreamReader linhaDePropriedadesSeparadasPorVirgulas = new StreamReader(caminhoDoArquivoDeImportacao))
        {
            while (!linhaDePropriedadesSeparadasPorVirgulas.EndOfStream)
            {
                string[] propriedades = linhaDePropriedadesSeparadasPorVirgulas.ReadLine()!.Split(';');

                Pet pet = new Pet(
                  id: Guid.Parse(propriedades[0]),
                  nome: propriedades[1],
                  tipo: TipoPet.Cachorro
                 );

                listaDePet.Add(pet);
            }
        }

        return listaDePet;
    }

}
