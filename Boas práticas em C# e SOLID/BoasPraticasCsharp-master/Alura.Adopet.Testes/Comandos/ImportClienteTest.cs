using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Utils;
using Alura.Adopet.Testes.Builders;
using Moq;

namespace Alura.Adopet.Testes.Comandos;
public class ImportClienteTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatAsync()
    {
        // Arrange
        var listaClientes = new List<Cliente>();
        var arquivo = LeitorArquivoBuilder.CriarMock(listaClientes);
        var serviceApi = ApiServiceBuilder.CriarMock<Cliente>();
        var import = new ImportCliente(serviceApi.Object, arquivo.Object);

        // Act
        await import.ExecutarAsync();

        // Assert
        serviceApi.Verify(_ => _.CreateAsync(It.IsAny<Cliente>()), Times.Never);
    }

    [Fact]
    public async Task QuandoArquivoNaoExistenteDeveGerarException()
    {
        //Arrange
        List<Cliente> listaClientes = new();
        var arquivo = LeitorArquivoBuilder.CriarMock(listaClientes);
        arquivo.Setup(_ => _.LerConteudoArquivo()).Throws<FileNotFoundException>();

        var serviceApi = ApiServiceBuilder.CriarMock<Cliente>();
        var import = new ImportCliente(serviceApi.Object, arquivo.Object);

        //Act
        var result = await import.ExecutarAsync();

        //Assert
        Assert.True(result.HasException<Exception>());
    }

    [Fact]
    public async Task VerificarSePetFoiImportado()
    {
        //Arrange
        List<Cliente> listaClientes = new();
        var cliente = new Cliente(
            id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
            nome: "Jeni Entity",
            email: "jeni@example.org",
            cpf: "123213123"
        );
        listaClientes.Add(cliente);
        var arquivo = LeitorArquivoBuilder.CriarMock(listaClientes);

        var serviceApi = ApiServiceBuilder.CriarMock<Cliente>();
        var import = new ImportCliente(serviceApi.Object, arquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync();
        var retorno = (SucessClientes)resultado.Successes[0];

        //Assert
        Assert.True(resultado.IsSuccess);
        Assert.Equal("Jeni Entity", retorno.Data.First().Nome);
    }


    [Fact]
    public async Task VerificarSePetFalhoImportacao()
    {
        //Arrange
        List<Cliente> listaClientes = new();
        var arquivo = LeitorArquivoBuilder.CriarMock(listaClientes);
        arquivo.Setup(_ => _.LerConteudoArquivo()).Throws<FileNotFoundException>();

        var serviceApi = ApiServiceBuilder.CriarMock<Cliente>();
        var import = new ImportCliente(serviceApi.Object, arquivo.Object);

        //Act
        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsFailed);
    }
}
