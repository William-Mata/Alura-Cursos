using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class PetJsonTest : IDisposable
{
    private readonly string _caminhoArquivo;

    public PetJsonTest()
    {
        var conteudo = @"[{
        ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
        ""Nome"": ""Mancha"",
        ""Tipo"": 1
        }]";

        File.WriteAllText("petCsvTeste.json", conteudo);
        _caminhoArquivo = Path.GetFullPath("petCsvTeste.json"); 
    }

    [Fact]
    public void VerificarSeRetornaListaDePet()
    {
        // Arrange
        // Act
        var lista = new PetJson(_caminhoArquivo).LerConteudoArquivo();

        // Assert
        Assert.NotNull(lista);
        Assert.Single(lista);
    }

    public void Dispose()
    {
        File.Delete(_caminhoArquivo);
    }
}
