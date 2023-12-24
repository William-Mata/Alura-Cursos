using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObejcts;

public class IndexPO : IClassFixture<Gerenciador> // Usando uma IClassFixture para gerencia o navegador.
{
    private IWebDriver _driver;
    private string _url = "https://localhost:7065/";
    private string _titulo = "Leilões Online";

    public IndexPO(Gerenciador gerenciador)
    {
        _driver = gerenciador.drive;
    }

    [Fact]
    public void AcessarIndexVerificarTituloUrl()
    {
        // Arrang
        // Act
        _driver.Navigate().GoToUrl(_url);

        // Assert
        Assert.Equal(_titulo, _driver.Title);
        Assert.Equal(_url, _driver.Url);
    }
}
