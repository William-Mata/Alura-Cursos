using OpenQA.Selenium;
using Alura.ByteBank.WebApp.Testes.Utils;

namespace Alura.ByteBank.WebApp.Testes.PageObjects;

public class ContaCorrentePO : IClassFixture<GerenciadorNavegador>
{
    private IWebDriver _driver;
    private string _url = "https://localhost:44309/ContaCorrentes/Index";
    public By linkContaCorrente;

    public ContaCorrentePO(GerenciadorNavegador gerenciador)
    {
        this._driver = gerenciador.driver;
        linkContaCorrente = By.LinkText("Conta-Corrente");
    }


    [Fact]
    public void AcessarContaCorrente()
    {
        // Arrange
        // Act
        _driver.FindElement(linkContaCorrente).Click();

        // Assert
        Assert.Equal(_url, _driver.Url);
    }
}
