using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Testes;

public class RealizarLogin : IDisposable
{
    private IWebDriver driver;

    public RealizarLogin()
    {
        this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

    }

    [Fact]
    public void AposRealizarLoginVerificarSeExisteOpcaoAgenciaMenu()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        var login = driver.FindElement(By.Id("Email"));
        var senha = driver.FindElement(By.Id("Senha"));
        var btnLogar = driver.FindElement(By.Id("btn-logar"));

        login.SendKeys("william@email.com");
        senha.SendKeys("senha01");

        // Act
        btnLogar.Click();

        // Assert
        Assert.Contains("Agência", driver.PageSource);
    }


    [Fact]
    public void RealizarLoginSemEmailSenha()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        var btnLogar = driver.FindElement(By.Id("btn-logar"));

        // Act
        btnLogar.Click();

        // Assert
        Assert.Contains("The Email field is required", driver.PageSource);
        Assert.Contains("The Senha field is required", driver.PageSource);

    }

    [Fact]
    public void RealizarLoginSemEmailSenhaInvalida()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        var login = driver.FindElement(By.Id("Email"));
        var senha = driver.FindElement(By.Id("Senha"));
        var btnLogar = driver.FindElement(By.Id("btn-logar"));

        login.SendKeys("william12@email.com");
        senha.SendKeys("senha012");

        // Act
        btnLogar.Click();

        // Assert
        Assert.Contains("Login", driver.PageSource);
    }

    public void Dispose()
    {
        driver.Close();
    }
}
