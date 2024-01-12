using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Utils;
using System.Reflection;

namespace Alura.Adopet.Testes.Testes;

public class GeraDocumentacaoTest
{


    [Fact]
    public void VerificarSeDocComandoEstaRetornandoDictionary()
    {
        //Arrange
        Assembly assemblytDocComando = Assembly.GetAssembly(typeof(DocComando))!;

        //Act
        Dictionary<string, DocComando> dicionarioDocComando = DocumentcaoSistema.ToDictionary(assemblytDocComando);

        //Assert
        Assert.NotEmpty(dicionarioDocComando);
        Assert.True(dicionarioDocComando.Count > 0);
    }

}
