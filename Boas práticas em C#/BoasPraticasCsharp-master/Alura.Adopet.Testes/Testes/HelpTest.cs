using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Testes.Testes;

public class HelpTest
{
    [Theory]
    [InlineData("help")]
    [InlineData("help import")]
    [InlineData("help list")]
    [InlineData("help show")]
    public async Task VerificarSeComandoExeceutaComs(string helpText)
    {
        // Arrange + Act
        var retorno = await new Help(helpText).ExecutarAsync();

        // Assert
        var resultado = (SucessDocs)retorno.Successes[0];
        Assert.True(resultado.Documentacao.Count() > 1);
    }

}