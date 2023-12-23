using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Reflection;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes;

public class PaginaContaCorrente : IDisposable
{

    private IWebDriver driver;
    public ITestOutputHelper Output;

    public PaginaContaCorrente(ITestOutputHelper output)
    {
        this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        Output = output;
    }

    [Fact]
    public void AcessarPaginaContaCorrenteVerificarQuantidadeElementos()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        driver.FindElement(By.Id("Email")).SendKeys("william@email.com"); ;
        driver.FindElement(By.Id("Senha")).SendKeys("senha01");
        driver.FindElement(By.Id("btn-logar")).Click();
        driver.FindElement(By.LinkText("Conta-Corrente")).Click();
        // Act
        IReadOnlyCollection<IWebElement> elements =  driver.FindElements(By.TagName("a"));
        foreach (IWebElement element in elements) { Output.WriteLine(element.Text); }

        // Assert
        Assert.True(elements.Count() == 12);
        Assert.Contains("https://localhost:44309/ContaCorrentes/Index", driver.Url);
    }

    public void Dispose()
    {
        driver.Close();
    }
}
