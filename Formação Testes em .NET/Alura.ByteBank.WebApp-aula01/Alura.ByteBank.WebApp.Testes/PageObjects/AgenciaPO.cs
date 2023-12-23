using OpenQA.Selenium;
using Alura.ByteBank.WebApp.Testes.Utils;

namespace Alura.ByteBank.WebApp.Testes.PageObjects;

public class AgenciaPO : IClassFixture<GerenciadorNavegador>
{
    private IWebDriver _driver;
    private string _url = "https://localhost:44309/Agencia/Index";
    public By linkAgencia;

    public AgenciaPO(GerenciadorNavegador gerenciador)
    {
        this._driver = gerenciador.driver;
        linkAgencia = By.LinkText("Agência");
    }

    [Fact]
    public void AcessarAgencia()
    {
        // Arrange
        // Act
        _driver.FindElement(linkAgencia).Click();

        // Assert
        Assert.Equal(_url, _driver.Url);
    }
}
