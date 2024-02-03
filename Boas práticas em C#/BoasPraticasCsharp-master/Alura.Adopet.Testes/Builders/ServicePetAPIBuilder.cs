using Alura.Adopet.Console.Models;
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

    //public static Mock<ServicePetAPI> CriarMockListPets(List<Pet> ListPets)
    //{
    //    var mock = new Mock<ServicePetAPI>(MockBehavior.Default, It.IsAny<HttpClient>());
    //    mock.Setup(_ => _.ListPetsAsync()).ReturnsAsync(ListPets);  
    //    return mock;
    //}

    public static Mock<ServicePetAPI> CriarMockListPets(List<Pet> lista)
    {
        var httpClientPet = new Mock<ServicePetAPI>(MockBehavior.Default,
            It.IsAny<HttpClient>());
        httpClientPet.Setup(_ => _.ListPetsAsync())
            .ReturnsAsync(lista);
        return httpClientPet;
    }
}
