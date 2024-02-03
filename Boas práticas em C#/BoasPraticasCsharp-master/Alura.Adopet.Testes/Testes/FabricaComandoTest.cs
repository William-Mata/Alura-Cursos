using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Comands.Interfaces;

namespace Alura.Adopet.Testes.Testes;

public class FabricaComandoTest
{
    [Theory]
    [InlineData(typeof(List))]
    [InlineData(typeof(Show))]
    [InlineData(typeof(Help))]
    [InlineData(typeof(Import))]
    [InlineData(null)]
    public void ValidarRetornoObjeto(Type? tipoObjeto)
    {
        // Arrange
        string[] comandoSerCriado = { tipoObjeto != null ? tipoObjeto.Name.ToString().ToLower() : "invalido" };

        // Act
        var comando = FabricaComando.FabricarComando(comandoSerCriado);
        var result = comando != null ? comando.GetType() : null;

        // Assert
        Assert.Equivalent(tipoObjeto, result);
    }
}
