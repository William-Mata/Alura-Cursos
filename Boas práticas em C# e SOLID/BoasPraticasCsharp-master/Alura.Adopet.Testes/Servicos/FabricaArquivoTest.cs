using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class FabricaArquivoTest : IDisposable
{
    private string _caminhoArquivoCsv;
    private string _caminhoArquivoJson;
    public FabricaArquivoTest()
    {
        File.WriteAllText("fabricaArquivoTest.csv", "");
        File.WriteAllText("fabricaArquivoTest.json", "");
        _caminhoArquivoCsv = Path.GetFullPath("fabricaArquivoTest.csv");
        _caminhoArquivoJson = Path.GetFullPath("fabricaArquivoTest.json");
    }

    [Fact]
    public void VerificarSeRetornaLeitorArquivoCsvPet()
    {
        // Arrange Act
        var leitorArquivo = FabricaArquivo.FabricarArquivoPet(_caminhoArquivoCsv);

        // Assert
        Assert.Same(typeof(PetCsv), leitorArquivo!.GetType());
    }

    [Fact]
    public void VerificarSeRetornaLeitorArquivoJsonPet()
    {
        // Arrange Act
        var leitorArquivo = FabricaArquivo.FabricarArquivoPet(_caminhoArquivoJson);

        // Assert
        Assert.NotNull(leitorArquivo);
        Assert.Same(typeof(PetJson), leitorArquivo.GetType());
    }

    [Fact]
    public void VerificarSeRetornaLeitorArquivoCsvCliente()
    {
        // Arrange Act
        var leitorArquivo = FabricaArquivo.FabricarArquivoCliente(_caminhoArquivoCsv);

        // Assert
        Assert.Same(typeof(ClienteCsv), leitorArquivo!.GetType());
    }

    [Fact]
    public void VerificarSeRetornaLeitorArquivoJsonCliente()
    {
        // Arrange Act
        var leitorArquivo = FabricaArquivo.FabricarArquivoCliente(_caminhoArquivoJson);

        // Assert
        Assert.NotNull(leitorArquivo);
        Assert.Same(typeof(ClienteJson), leitorArquivo.GetType());
    }

    [Fact]
    public void VerificarSeRetornaNullQuandoExtensaoNaoForSuportada()
    { 
        // Arrange Act
        var leitorArquivo = FabricaArquivo.FabricarArquivoPet("pets.xsl");

        // Assert
        Assert.Null(leitorArquivo);
    }

    public void Dispose()
    {
        File.Delete(_caminhoArquivoJson);
        File.Delete(_caminhoArquivoCsv);
    }

}
