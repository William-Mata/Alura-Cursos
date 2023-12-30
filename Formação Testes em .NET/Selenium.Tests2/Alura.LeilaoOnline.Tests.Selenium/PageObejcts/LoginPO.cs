using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

[Collection("Chrome Driver")]
public class LoginPO : PadraoPO
{
    private string _rgbaErro = "rgba(255, 0, 0, 1)";
    private By _login;
    private By _password;
    private By _btnLogin;
    private By _msgsValidacoesRegistro;

    public LoginPO(Gerenciador gerenciador)
    {
        driver = gerenciador.drive;
        url = "https://localhost:7065/Autenticacao/Login";
        _login = By.Id("Login");
        _password = By.Id("Password");
        _btnLogin = By.Id("btnLogin");
        _msgsValidacoesRegistro = By.CssSelector("form span");
    }

    [Fact]
    public void FazerLoginVerificarSeLogou()
    {
        // Arrrange
        driver.Navigate().GoToUrl(url);
        driver.FindElement(_login).SendKeys("fulano@example.org");
        driver.FindElement(_password).SendKeys("123");

        // Act
        driver.FindElement(_btnLogin).Click();

        // Assert
        Assert.Equal("https://localhost:7065/Interessadas", driver.Url);
        Assert.Contains("Logout", driver.PageSource);
    }

    [Fact]
    public void FazerLoginComInformacoesInvalidaVerificarRetorno()
    {
        // Arrrange
        driver.Navigate().GoToUrl(url);
        driver.FindElement(_login).SendKeys("teste@example.org");
        driver.FindElement(_password).SendKeys("12356");

        // Act
        driver.FindElement(_btnLogin).Click();

        // Assert
        Assert.Equal(url, driver.Url);
        Assert.Contains("Login", driver.PageSource);
    }

    [Fact]
    public void FazerLoginSemInformacoesVerificarRetorno()
    {
        // Arrrange
        driver.Navigate().GoToUrl(url);
        driver.FindElement(_login).SendKeys("");
        driver.FindElement(_password).SendKeys("");

        // Act
        driver.FindElement(_btnLogin).Click();
        var elements = driver.FindElements(_msgsValidacoesRegistro).Where(x => x.GetCssValue("color") == _rgbaErro).ToList();

        // Assert
        Assert.Equal(url, driver.Url);
        Assert.Contains("Login", driver.PageSource);
        elements.ForEach(x => Assert.NotEmpty(x.Text));
    }


    [Fact]
    public void FazerLoginAdmVerificarRetorno()
    {
        // Arrrange
        driver.Navigate().GoToUrl(url);
        driver.FindElement(_login).SendKeys("admin@example.org");
        driver.FindElement(_password).SendKeys("123");

        // Act
        driver.FindElement(_btnLogin).Click();

        // Assert
        Assert.Equal("https://localhost:7065/Leiloes", driver.Url);
        Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
    }
}
