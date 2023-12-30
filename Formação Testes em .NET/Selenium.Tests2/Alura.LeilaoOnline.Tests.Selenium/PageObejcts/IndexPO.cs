using Alura.LeilaoOnline.Selenium.Utils;
namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;


public class IndexPO : PadraoPO, IClassFixture<Gerenciador> // Usando uma IClassFixture para gerencia o navegador.
{
    private string _titulo = "Leilões Online";

    public IndexPO(Gerenciador gerenciador)
    {
        driver = gerenciador.drive;
        url = "https://localhost:7065/";
    }

    [Fact]
    public void AcessarIndexVerificarTituloUrl()
    {
        // Arrang
        // Act
        driver.Navigate().GoToUrl(url);

        // Assert
        Assert.Equal(_titulo, driver.Title);
        Assert.Equal(url, driver.Url);
    }
}
