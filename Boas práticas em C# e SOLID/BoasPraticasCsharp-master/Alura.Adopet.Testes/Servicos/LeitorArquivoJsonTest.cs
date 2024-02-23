using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Abstracoes;
using Alura.Adopet.Console.Services.Arquivos;
using System.Text.Json;

namespace Alura.Adopet.Testes.Servicos;

public class LeitorArquivoJsonTest : IDisposable
{
    private ILeitorArquivos<Pet> _leitorArquivo;
    private string _caminhoArquivo;

    public LeitorArquivoJsonTest()
    {
        var lista = new List<Pet>();
        lista.Add(new Pet(new Guid("68286fbf-f6f4-4924-adab-0637511813e0"), "Mancha", TipoPet.Cachorro));
        lista.Add(new Pet(new Guid("68286fbf-f6f4-4924-adab-0637511813e0"), "Mancha", TipoPet.Cachorro));
        var linha = JsonSerializer.Serialize(lista);
        File.WriteAllText("lista.json", linha);
        _caminhoArquivo = Path.GetFullPath("lista.json");
        _leitorArquivo = FabricaArquivo.FabricarArquivoPet(_caminhoArquivo)!;
    }

    [Fact]
    public void VerificarArquivoSeArquivoRetornaList()
    {
        // Arrange
        // Act
        var listaDePets = _leitorArquivo.LerConteudoArquivo();

        // Assert
        Assert.NotNull(listaDePets);
        Assert.True(listaDePets.Count() == 2);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void VerificarQuandoArquivoNaoExistirRetornaException()
    {
        // Arrange
        _leitorArquivo = new PetJson("");

        // Act
        // Assert
        Assert.ThrowsAny<Exception>(() => _leitorArquivo.LerConteudoArquivo());
    }

    public void Dispose()
    {
        File.Delete(_caminhoArquivo);
    }
}
