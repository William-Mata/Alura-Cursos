using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Services.Arquivos;

public class ClienteCsv : LeitorArquivoCsv<Cliente>
{
    public ClienteCsv(string caminhoDoArquivoDeImportacao) : base(caminhoDoArquivoDeImportacao)
    {
    }

    public override Cliente ExtrairPorLinha(string linha)
    {
        if (string.IsNullOrEmpty(linha))
        {
            throw new ArgumentNullException("linha vazia ou null");
        }

        string[] propriedades = linha!.Split(';');

        if (propriedades.Length < 3 || propriedades.Length > 4)
        {
            throw new ArgumentOutOfRangeException("Uma ou mais propriedades estão faltando.");
        }

        if (!Guid.TryParse(propriedades[0], null, out _))
        {
            throw new ArgumentException("Guid Inválido.");
        }

        if (string.IsNullOrEmpty(propriedades[2]))
        {
            throw new ArgumentException("E-mail Inválido.");
        }

        Cliente cliente = new Cliente(
            id: Guid.Parse(propriedades[0]),
            nome: propriedades[1],
            email: propriedades[2],
            cpf: propriedades[3]);

        return cliente;
    }
}
