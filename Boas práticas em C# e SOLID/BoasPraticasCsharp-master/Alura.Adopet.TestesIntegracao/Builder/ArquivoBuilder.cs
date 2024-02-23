using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Services.Arquivos;
using Moq;

namespace Alura.Adopet.TestesIntegracao.Builder;

internal static class ArquivoBuilder
{
    public static Mock<PetCsv> CriarMock(List<Pet> pets)
    {
        var mock = new Mock<PetCsv>(MockBehavior.Default, It.IsAny<string>());
        mock.Setup(_ => _.LerConteudoArquivo()).Returns(pets);

        return mock;
    }
}
