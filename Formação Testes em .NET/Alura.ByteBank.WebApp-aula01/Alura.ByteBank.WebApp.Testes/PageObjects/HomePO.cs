using Alura.ByteBank.WebApp.Testes.Utils;
using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Testes.PageObjects;

public class HomePO : IClassFixture<GerenciadorNavegador>
{
    private string _url = "https://localhost:44309/Home/Index";
    private IWebDriver _driver;
    private GerenciadorNavegador _gerenciador;
    private By _linkHome;
    private ClientePO? _clientePO;
    private AgenciaPO? _agenciaPO;
    private ContaCorrentePO? _contaCorrentePO;
    
    public HomePO(GerenciadorNavegador gerenciador)
    {
        _gerenciador = gerenciador;
        _driver = _gerenciador.driver;
        _linkHome = By.LinkText("Home");
    }

    [Fact]
    public void AcessarHome()
    {
        // Arrange
        // Act
        _driver.FindElement(_linkHome).Click();

        // Assert
        Assert.Contains("Boas-Vindas!", _driver.PageSource);
        Assert.Equal(_url, _driver.Url);
    }

    [Fact]
    public void AcessarHomeDepoisAgencia()
    {
        // Arrange
        _agenciaPO = new AgenciaPO(_gerenciador);
        _driver.FindElement(_linkHome).Click();
        var linkHome = _driver.Url;

        // Act
        _agenciaPO.AcessarAgencia();

        // Assert
        Assert.Contains("Agência", _driver.PageSource);
        Assert.Equal(_url, linkHome);
    }


    [Fact]
    public void AcessarHomeDepoisCliente()
    {
        // Arrange
        _clientePO = new ClientePO(_gerenciador);
        _driver.FindElement(_linkHome).Click();
        var linkHome = _driver.Url;

        // Act
        _clientePO.AcessarCliente();

        // Assert
        Assert.Contains("Clientes", _driver.PageSource);
        Assert.Equal(_url, linkHome);
    }

    [Fact]
    public void AcessarHomeDepoisContaCorrente()
    {
        // Arrange
        _contaCorrentePO = new ContaCorrentePO(_gerenciador);
        _driver.FindElement(_linkHome).Click();
        var linkHome = _driver.Url;

        // Act
        _contaCorrentePO.AcessarContaCorrente();

        // Assert
        Assert.Contains("Contas-Correntes", _driver.PageSource);
        Assert.Equal(_url, linkHome);
    }
}
