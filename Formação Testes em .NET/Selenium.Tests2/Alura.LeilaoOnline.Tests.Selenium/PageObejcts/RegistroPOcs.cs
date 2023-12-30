using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;
namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

public class RegistroPOcs : PadraoPO, IClassFixture<Gerenciador>
{   
    private string _rgbaErro = "rgba(255, 0, 0, 1)";
    private By _nome;
    private By _email;
    private By _password;
    private By _confirmPassowrd;
    private By _btnRegistro;
    private By _msgsValidacoesRegistro;

    public RegistroPOcs(Gerenciador gerenciador)
    {
        driver = gerenciador.drive;
        url = "https://localhost:7065/";
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
        driver.Navigate().GoToUrl(url);
        driver.FindElement(_nome).SendKeys("William");
        driver.FindElement(_email).SendKeys("william@email.com");
        driver.FindElement(_password).SendKeys("123456789");
        driver.FindElement(_confirmPassowrd).SendKeys("123456789");

        // Act
        driver.FindElement(_btnRegistro).Click();

        // Assert
        Assert.Contains("Obrigado por se registrar!", driver.PageSource);
        Assert.Equal("https://localhost:7065/Usuarios/Agradecimento", driver.Url);
    }

    [Fact]
    public void PreencherInformacoesInvalidasRegistrarVerificarSeRegistrou()
    {
        // Arrange
        driver.Navigate().GoToUrl(url);
        driver.FindElement(_nome).SendKeys("");
        driver.FindElement(_email).SendKeys("");
        driver.FindElement(_password).SendKeys("");
        driver.FindElement(_confirmPassowrd).SendKeys("12345678910");

        // Act
        driver.FindElement(_btnRegistro).Click();
        var elements = driver.FindElements(_msgsValidacoesRegistro).Where(x => x.GetCssValue("color") == _rgbaErro).ToList();

        // Assert
        elements.ForEach(x => Assert.NotEmpty(x.Text));
    }

}
