using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class ClienteCsvTest : IDisposable
{
    private readonly string _caminhoArquivo;

    public ClienteCsvTest()
    {
        var conteudo = @"68286fbf-f6f4-4924-adab-0637511672e0; William; teste@teste.com; 12312312";
        File.WriteAllText("clienteCsvTeste.csv", conteudo);
        _caminhoArquivo = Path.GetFullPath("clienteCsvTeste.csv"); 
    }

    [Fact]
    public void VerificarSeRetornaListaDeCliente()
    {
        // Arrange
        // Act
        var lista = new ClienteCsv(_caminhoArquivo).LerConteudoArquivo();

        // Assert
        Assert.NotNull(lista);
        Assert.Single(lista);
    }

    public void Dispose()
    {
        File.Delete(_caminhoArquivo);
    }
}
