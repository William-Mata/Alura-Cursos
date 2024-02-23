using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Services.Arquivos;

public class PetCsv : LeitorArquivoCsv<Pet>
{
    public PetCsv(string caminhoDoArquivoDeImportacao) : base(caminhoDoArquivoDeImportacao)
    {
    }

    public override Pet ExtrairPorLinha(string linha)
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

        if (!int.TryParse(propriedades[2], out _) || int.Parse(propriedades[2]) < 0 || int.Parse(propriedades[2]) > 1)
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
