using Alura.Adopet.Console.Comands;
using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Testes.Builders;

namespace Alura.Adopet.Testes
{
    public class ImportIntegracaoTest
    {
   
        [Fact]
        public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            //Arrange
            var listaDePet = new List<Pet>();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
                  "Lima", TipoPet.Cachorro); 
            listaDePet.Add(pet);
            var arquivo = ArquivoBuilder.CriarMock(listaDePet);       
            var servicePetAPI = new ServicePetAPI(new HttpClientFactory().CreateClient());
            var import = new Import(servicePetAPI, arquivo.Object);
            string[] args = { "import", "lista.csv" };
            
            //Act
            await import.ExecutarAsync(args);
            
            //Assert
            var listaPet = await servicePetAPI.ListPetsAsync();
            Assert.NotNull(listaPet);
        }
    }
}
