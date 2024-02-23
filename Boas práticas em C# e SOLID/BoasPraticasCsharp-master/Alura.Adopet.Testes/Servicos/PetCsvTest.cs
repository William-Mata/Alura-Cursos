using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class PetCsvTest : IDisposable
{
    private readonly string _caminhoArquivo;

    public PetCsvTest()
    {
        var conteudo = @"68286fbf-f6f4-4924-adab-0637511672e0; Pretinha; 1";
        File.WriteAllText("petCsvTeste.csv", conteudo);
        _caminhoArquivo = Path.GetFullPath("petCsvTeste.csv"); 
    }

    [Fact]
    public void VerificarSeRetornaListaDePet()
    {
        // Arrange
        // Act
        var lista = new PetCsv(_caminhoArquivo).LerConteudoArquivo();

        // Assert
        Assert.NotNull(lista);
        Assert.Single(lista);
    }

    public void Dispose()
    {
        File.Delete(_caminhoArquivo);
    }
}
