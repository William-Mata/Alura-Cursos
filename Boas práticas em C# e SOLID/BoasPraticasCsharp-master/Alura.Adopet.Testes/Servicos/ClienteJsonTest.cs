using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class ClienteJsonTest : IDisposable
{
    private readonly string _caminhoArquivo;

    public ClienteJsonTest()
    {
        var conteudo = @"[{
        ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
        ""Nome"": ""William"",
        ""Email"": ""teste@teste.com"" 
        }]";

        File.WriteAllText("clienteCsvTeste.json", conteudo);
        _caminhoArquivo = Path.GetFullPath("clienteCsvTeste.json"); 
    }

    [Fact]
    public void VerificarSeRetornaListaDeCliente()
    {
        // Arrange
        // Act
        var lista = new ClienteJson(_caminhoArquivo).LerConteudoArquivo();

        // Assert
        Assert.NotNull(lista);
        Assert.Single(lista);
    }

    public void Dispose()
    {
        File.Delete(_caminhoArquivo);
    }
}
