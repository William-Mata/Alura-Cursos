using Alura.Adopet.Console.Services.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builders;

public static class LeitorArquivoBuilder
{
    public static Mock<ILeitorArquivos<T>> CriarMock<T>(List<T> objetos)
    {
        var mock = new Mock<ILeitorArquivos<T>>(MockBehavior.Default);
        mock.Setup(_ => _.LerConteudoArquivo()).Returns(objetos);

        return mock;
    }
}
