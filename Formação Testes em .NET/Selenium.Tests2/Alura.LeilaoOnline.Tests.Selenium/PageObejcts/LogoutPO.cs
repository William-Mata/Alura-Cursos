using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

[Collection("Chrome Driver")]
public class LogoutPO : PadraoPO
{
    private By _btnMeuPerfil;
    private By _btnLogout;

    public LogoutPO(Gerenciador gerenciador)
    {
        driver = gerenciador.drive;
        _loginPO = new LoginPO(gerenciador);
        _btnMeuPerfil = By.Id("meu-perfil");
        _btnLogout = By.Id("logout");
    }

    [Fact]
    public void RealziarLogout()
    {
        // Arrange
        _loginPO.FazerLoginAdmVerificarRetorno();
        var btnMeuPerfil = driver.FindElement(_btnMeuPerfil);
        var btnLogout = driver.FindElement(_btnLogout);

        // Act 
        IAction action = new Actions(driver).MoveToElement(btnMeuPerfil).MoveToElement(btnLogout).Click().Build();
        action.Perform();

        // Assert
        Assert.Equal("https://localhost:7065/", driver.Url);
    }
}

