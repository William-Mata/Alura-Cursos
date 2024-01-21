using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Comands.Interfaces;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes.Testes;

public class LeitorDeArquivoTest : IDisposable
{
    private string caminhoArquivo;
    private Arquivo _arquivo;

    public LeitorDeArquivoTest()
    {
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        File.WriteAllText("lista.csv", linha);
        caminhoArquivo = Path.GetFullPath("lista.csv");
        _arquivo = new Arquivo(caminhoArquivo);
    }


    [Fact]
    public void VerificarArquivoSeArquivoRetornaList()
    {
        // Arrange
        // Act
        var listaDePets = _arquivo.LeitorConteudoArquivoPets();

        // Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }


    [Fact]
    public void QuandoArquivoNaoExistirRetornaException()
    {
        // Arrange
        _arquivo = new Arquivo("");

        // Act
        // Assert
        Assert.ThrowsAny<Exception>(() => _arquivo.LeitorConteudoArquivoPets());
    }

    [Fact]
    public void QuandoArquivoForNullRetornaListVazia()
    {

        // Arrange
        string linha = null;
        File.WriteAllText("lista.csv", linha);

        // Act
        var listaDePets = _arquivo.LeitorConteudoArquivoPets();

        // Assert
        Assert.Empty(listaDePets);
    }


    public void Dispose()
    {
       File.Delete(caminhoArquivo);
    }
}
