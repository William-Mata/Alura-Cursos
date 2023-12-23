using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Reflection;
using Alura.ByteBank.WebApp.Testes.Utils;

namespace Alura.ByteBank.WebApp.Testes.PageObjects;

public class ClientePO : IClassFixture<GerenciadorNavegador>
{
    private IWebDriver _driver;
    private string _url = "https://localhost:44309/Clientes/Index";
    private By _linkCliente;

    public ClientePO(GerenciadorNavegador gerenciador)
    {
        this._driver = gerenciador.driver;
        _linkCliente = By.LinkText("Cliente");
    }

    [Fact]
    public void AcessarCliente()
    {
        // Arrange
        // Act
        _driver.FindElement(_linkCliente).Click();

        // Assert
        Assert.Equal(_url, _driver.Url);
    }
}
