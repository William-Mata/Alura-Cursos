using Alura.Adopet.Console.Services.Interfaces;
using Moq;

namespace Alura.Adopet.Testes.Builders;

public static class ApiServiceBuilder
{
    public static Mock<IServiceAPI<T>> CriarMock<T>()
    {
        var mock = new Mock<IServiceAPI<T>>(MockBehavior.Default);
        return mock;
    }

    public static Mock<IServiceAPI<T>> CriarMockListPets<T>(List<T> lista)
    {
        var apiService = new Mock<IServiceAPI<T>>(MockBehavior.Default);
        apiService.Setup(_ => _.ListAsync())
            .ReturnsAsync(lista);
        return apiService;
    }
}
