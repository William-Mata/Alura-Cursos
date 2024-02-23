using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class LeitorArquivoCsvTest : IDisposable
{
    private string caminhoArquivo;
    private PetCsv _leitorArquivo;

    public LeitorArquivoCsvTest()
    {
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        File.WriteAllText("lista2.csv", linha);
        caminhoArquivo = Path.GetFullPath("lista2.csv");
        _leitorArquivo = new PetCsv(caminhoArquivo);
    }

    [Fact]
    public void VerificarSeExtracaoDePetDoCsvEValida()
    {
        //Arrange
        var linhaPetTexto = $"{new Guid()}; Pretinha; 1";

        //Act
        Pet pet = _leitorArquivo.ExtrairPorLinha(linhaPetTexto);

        // Assert
        Assert.NotNull(pet);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void VerificarErroAoExtrairNullOuVazio(string? linhaPetTexto)
    {
        //Arrange
        //Act
        // Assert
        Assert.ThrowsAny<ArgumentNullException>(() => _leitorArquivo.ExtrairPorLinha(linhaPetTexto));
    }

    [Fact]
    public void VerificarErroAoEnviarInformacoesIncompleta()
    {
        //Arrange
        var linhaPetTexto = $"{new Guid()}; 1";

        //Act
        // Assert
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() => _leitorArquivo.ExtrairPorLinha(linhaPetTexto));
    }

    [Fact]
    public void VerificarErroAoEnviarGuidInvalido()
    {
        //Arrange
        var linhaPetTexto = $"12321; Pretinha; 1";

        //Act
        // Assert
        Assert.ThrowsAny<ArgumentException>(() => _leitorArquivo.ExtrairPorLinha(linhaPetTexto));
    }

    [Fact]
    public void VerificarErroAoEnviarTipoPetnvalido()
    {
        //Arrange
        var linhaPetTexto = $"{new Guid()}; Pretinha; 5";

        //Act
        // Assert
        Assert.ThrowsAny<ArgumentException>(() => _leitorArquivo.ExtrairPorLinha(linhaPetTexto));
    }


    [Fact]
    public void VerificarArquivoSeArquivoRetornaList()
    {
        // Arrange
        // Act
        var listaDePets = _leitorArquivo.LerConteudoArquivo();

        // Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNullRetornaListVazia()
    {
        // Arrange
        File.WriteAllText("lista2.csv", null);

        // Act
        var listaDePets = _leitorArquivo.LerConteudoArquivo();

        // Assert
        Assert.Empty(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistirRetornaException()
    {
        // Arrange
        _leitorArquivo = new PetCsv("");

        // Act
        // Assert
        Assert.ThrowsAny<Exception>(() => _leitorArquivo.LerConteudoArquivo());
    }

    public void Dispose()
    {
        File.Delete(caminhoArquivo);
    }
}
