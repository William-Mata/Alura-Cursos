using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Util;
using Moq;

namespace Alura.Adopet.Testes.Builders;

public static class ArquivoBuilder
{
    public static Mock<Arquivo> CriarMock(List<Pet> pets)
    {
        var mock = new Mock<Arquivo>(MockBehavior.Default, It.IsAny<string>());
        mock.Setup(_ => _.LeitorConteudoArquivoPets()).Returns(pets);

        return mock;
    }
}
