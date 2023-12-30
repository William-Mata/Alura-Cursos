using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

[Collection("Chrome Driver")]
public class LanceLeilaoPO : PadraoPO
{
    private By _lanceAtualLeilao;
    private By _valorLance;
    private By _btnDarLance;
    private NavegarLeilaoPO _leilao;

    public LanceLeilaoPO(Gerenciador gerenciador)
    {
        _leilao = new NavegarLeilaoPO(gerenciador);
        driver = gerenciador.drive;
        url = "https://localhost:7065/Home/Detalhes/";
        _lanceAtualLeilao = By.Id("lanceAtual");
        _valorLance = By.ClassName("input-lance");
        _btnDarLance = By.Id("btnDarLance");
    }

    [Fact]
    public void DarLanceLeilao()
    {
        // Arrange
        _leilao.NavegarParaLeilaoEmAndamento();
        var elementLanceAtual = driver.FindElement(_lanceAtualLeilao);
        var valorLance = driver.FindElement(_valorLance);
        valorLance.Clear();
        valorLance.SendKeys("200");

        // Act
        driver.FindElement(_btnDarLance).Click();
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8)); // CRIA UM WAIT 
        bool iguais = wait.Until(drv => double.Parse(elementLanceAtual.Text, System.Globalization.NumberStyles.Currency) == 200); // DURANTE O WAIT ELE FICA VALIDANDO A CONDIÇÃO

        // Assert
        Assert.True(iguais);
    }
}
