using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;
namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

public class RegistroPOcs : IClassFixture<Gerenciador>
{
    private IWebDriver _driver;
    private string _url = "https://localhost:7065/";
    private string _rgbaErro = "rgba(255, 0, 0, 1)";
    private By _nome;
    private By _email;
    private By _password;
    private By _confirmPassowrd;
    private By _btnRegistro;
    private By _msgsValidacoesRegistro;

    public RegistroPOcs(Gerenciador gerenciador)
    {
        _driver = gerenciador.drive;
        _nome = By.Id("Nome");
        _email = By.Id("Email");
        _password = By.Id("Password");
        _confirmPassowrd = By.Id("ConfirmPassword");
        _btnRegistro = By.Id("btnRegistro");
        _msgsValidacoesRegistro = By.CssSelector("form span");
    }

    [Fact]
    public void PreencherInformacoesRegistrarVerificarSeRegistrou()
    {
        // Arrange
        _driver.Navigate().GoToUrl(_url);
        _driver.FindElement(_nome).SendKeys("William");
        _driver.FindElement(_email).SendKeys("william@email.com");
        _driver.FindElement(_password).SendKeys("123456789");
        _driver.FindElement(_confirmPassowrd).SendKeys("123456789");

        // Act
        _driver.FindElement(_btnRegistro).Click();

        // Assert
        Assert.Contains("Obrigado por se registrar!", _driver.PageSource);
        Assert.Equal("https://localhost:7065/Usuarios/Agradecimento", _driver.Url);
    }

    [Fact]
    public void PreencherInformacoesInvalidasRegistrarVerificarSeRegistrou()
    {
        // Arrange
        _driver.Navigate().GoToUrl(_url);
        _driver.FindElement(_nome).SendKeys("");
        _driver.FindElement(_email).SendKeys("");
        _driver.FindElement(_password).SendKeys("");
        _driver.FindElement(_confirmPassowrd).SendKeys("12345678910");

        // Act
        _driver.FindElement(_btnRegistro).Click();
        var elements = _driver.FindElements(_msgsValidacoesRegistro).Where(x => x.GetCssValue("color") == _rgbaErro).ToList();

        // Assert
        elements.ForEach(x => Assert.NotEmpty(x.Text));
    }

}
