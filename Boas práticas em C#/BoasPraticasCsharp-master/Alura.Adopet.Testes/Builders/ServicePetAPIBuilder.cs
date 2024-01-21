using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Util;
using Moq;

namespace Alura.Adopet.Testes.Builders;

public class ServicePetAPIBuilder
{

    public static Mock<ServicePetAPI> CriarMock()
    {
        var mock = new Mock<ServicePetAPI>(MockBehavior.Default, It.IsAny<HttpClient>());

        return mock;
    }
}
