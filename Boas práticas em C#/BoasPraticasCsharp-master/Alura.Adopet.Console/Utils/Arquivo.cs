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
                var stringPropriedadesPet = linhaDePropriedadesSeparadasPorVirgulas.ReadLine()!;
                var pet = ExtrairPetPorLinha(stringPropriedadesPet);

                listaDePet.Add(pet);
            }
        }

        return listaDePet;
    }

    public static Pet ExtrairPetPorLinha(this string linha)
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
