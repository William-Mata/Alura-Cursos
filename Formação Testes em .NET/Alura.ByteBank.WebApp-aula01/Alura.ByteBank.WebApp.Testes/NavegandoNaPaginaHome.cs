using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Testes;

public class NavegandoNaPaginaHome : IDisposable
{
    private IWebDriver _driver;

    public NavegandoNaPaginaHome()
    {
        var chromeDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        _driver = chromeDriver;
    }


    [Fact]
    public void CarregarPaginaHomeVerificarTituloDaPagina()
    {
        // Arrange
        //Act
        _driver.Navigate().GoToUrl("https://localhost:44309/");

        //Assert
        Assert.Contains("WebApp", _driver.Title);
    }

    [Fact]
    public void CarregarPaginaHomeVerificarOpcoesDaPagina()
    {
        // Arrange

        //Act
        _driver.Navigate().GoToUrl("https://localhost:44309/");

        //Assert
        Assert.Contains("Home", _driver.PageSource);
        Assert.Contains("Login", _driver.PageSource);
    }


    [Fact]
    public void VerificarAcessoAPaginaSemLogar()
    {
        // Arrange
        //Act
        _driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

        //Assert
        Assert.Contains("https://localhost:44309/Agencia/Index", _driver.Url);
        Assert.Contains("401", _driver.PageSource);
    }

    public void Dispose()
    {
        _driver.Quit();
    }
}
