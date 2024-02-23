using Alura.Adopet.Console.Comands;

namespace Alura.Adopet.Testes.Comandos;

public class FabricaComandoTest
{
    [Theory]
    [InlineData(typeof(List))]
    [InlineData(typeof(Show))]
    [InlineData(typeof(Help))]
    [InlineData(typeof(Import))]
    [InlineData(typeof(ImportCliente))]
    [InlineData(null)]
    public void ValidarRetornoObjeto(Type? tipoObjeto)
    {
        // Arrange
        string[] comandoSerCriado = { tipoObjeto != null ? tipoObjeto.Name.ToString().ToLower() : "invalido" };
        comandoSerCriado[0] = comandoSerCriado[0] == "importcliente" ? "import-cliente" : comandoSerCriado[0];

        // Act
        var comando = FabricaComando.FabricarComando(comandoSerCriado);
        var result = comando != null ? comando.GetType() : null;

        // Assert
        Assert.Equivalent(tipoObjeto, result);
    }
}
