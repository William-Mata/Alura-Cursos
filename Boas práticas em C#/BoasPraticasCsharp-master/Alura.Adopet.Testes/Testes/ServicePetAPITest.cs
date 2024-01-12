using Alura.Adopet.Console.Services;

namespace Alura.Adopet.Testes.Testes;

public class ServicePetAPITest
{
    [Fact]
    public async Task ListPetsAsyncVerificarSeNaoEstaVazia()
    {
        // Arrange
        ServicePetAPI servicePetAPI = new ServicePetAPI();

        // Act
        var pets = await servicePetAPI.ListPetsAsync();

        // Assert
        Assert.NotNull(pets);
    }

    [Fact]
    public async Task VerificarSeApiEstaForaDoAr()
    {
        // Arrange
        ServicePetAPI servicePetAPI = new ServicePetAPI("http://localhost:5052");

        // Act Assert
        await Assert.ThrowsAnyAsync<Exception>(() => servicePetAPI.ListPetsAsync());
    }
}