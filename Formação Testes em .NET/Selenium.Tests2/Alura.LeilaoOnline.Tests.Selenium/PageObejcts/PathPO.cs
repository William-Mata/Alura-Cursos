using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

[Collection("Chrome Driver")]
public class PathPO : PadraoPO
{
    private By _path;

    public PathPO(Gerenciador gerenciador)
    {
        _loginPO = new LoginPO(gerenciador);
        driver = gerenciador.drive;
        _path = By.XPath("//body/div[contains(@class, 'container')]/*//div[contains(@class, 'minhas-ofertas')]/*//tbody/tr[last()]/td[2]");
    }


    [Fact]
    public void TestarPathPrimeiraOpcao()
    {
        // Arrange
        _loginPO.FazerLoginVerificarSeLogou();

        // Act
        var ultimoElementoSegundaCelula = driver.FindElement(_path).Text;

        // Assert
        Assert.Equal("200", ultimoElementoSegundaCelula);
    }
}
