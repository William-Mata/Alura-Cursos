using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

[Collection("Chrome Driver")]
public class LoginPO
{
    private string _url = "https://localhost:7065/Autenticacao/Login";
    private string _rgbaErro = "rgba(255, 0, 0, 1)";
    private IWebDriver _driver;
    private By _login;
    private By _password;
    private By _btnLogin;
    private By _msgsValidacoesRegistro;
    

    public LoginPO(Gerenciador gerenciador)
    {
        _driver = gerenciador.drive;
        _login = By.Id("Login");
        _password = By.Id("Password");
        _btnLogin = By.Id("btnLogin");
        _msgsValidacoesRegistro = By.CssSelector("form span");
    }

    [Fact]
    public void FazerLoginVerificarSeLogou()
    {
        // Arrrange
        _driver.Navigate().GoToUrl(_url);
        _driver.FindElement(_login).SendKeys("fulano@example.org");
        _driver.FindElement(_password).SendKeys("123");

        // Act
        _driver.FindElement(_btnLogin).Click();

        // Assert
        Assert.Equal("https://localhost:7065/Interessadas", _driver.Url);
        Assert.Contains("Logout", _driver.PageSource);
    }

    [Fact]
    public void FazerLoginComInformacoesInvalidaVerificarRetorno()
    {
        // Arrrange
        _driver.Navigate().GoToUrl(_url);
        _driver.FindElement(_login).SendKeys("teste@example.org");
        _driver.FindElement(_password).SendKeys("12356");

        // Act
        _driver.FindElement(_btnLogin).Click();

        // Assert
        Assert.Equal(_url, _driver.Url);
        Assert.Contains("Login", _driver.PageSource);
    }

    [Fact]
    public void FazerLoginSemInformacoesVerificarRetorno()
    {
        // Arrrange
        _driver.Navigate().GoToUrl(_url);
        _driver.FindElement(_login).SendKeys("");
        _driver.FindElement(_password).SendKeys("");

        // Act
        _driver.FindElement(_btnLogin).Click();
        var elements = _driver.FindElements(_msgsValidacoesRegistro).Where(x => x.GetCssValue("color") == _rgbaErro).ToList();

        // Assert
        Assert.Equal(_url, _driver.Url);
        Assert.Contains("Login", _driver.PageSource);
        elements.ForEach(x => Assert.NotEmpty(x.Text));
    }

}
