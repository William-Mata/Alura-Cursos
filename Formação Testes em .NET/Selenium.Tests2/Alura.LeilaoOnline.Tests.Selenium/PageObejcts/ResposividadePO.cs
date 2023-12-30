using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Interactions;
using System.Reflection;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

public class ResposividadePO : IDisposable
{
    private IWebDriver _driver;
    private By _menu;
    private By _menuMobile;

    public ResposividadePO()
    {
        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        _menuMobile = By.ClassName("sidenav-trigger");
        _menu = By.XPath("//body/*//ul[contains(@class, 'right hide-on-med-and-down')]/li/a[@href='/Autenticacao/Login']");
    }

    [Fact]
    public void TestarResposividadeMobile()
    {
        // Arrange
        var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
        deviceSettings.Width = 400;
        deviceSettings.Height = 800;
        deviceSettings.UserAgent = "Customizada";
        var options = new ChromeOptions();
        options.EnableMobileEmulation(deviceSettings);
        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        _driver.Navigate().GoToUrl("https://localhost:7065/");

        // Act
        var isMenuMobile = _driver.FindElement(_menuMobile).Displayed;


        // Assert
        Assert.True(isMenuMobile);
    }

    [Fact]
    public void TestarResposividadeNormal()
    {
        // Arrange
        _driver.Navigate().GoToUrl("https://localhost:7065/");

        // Act
        var isMenu= _driver.FindElement(_menu).Displayed;


        // Assert
        Assert.True(isMenu);
    }


    public void Dispose()
    {
        _driver.Close();
    }
}
