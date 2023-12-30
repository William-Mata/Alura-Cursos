using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;


[Collection("Chrome Driver")]
public class NavegarLeilaoPO : PadraoPO
{
    private By _btnAdicionarLeilao;

    
    public NavegarLeilaoPO(Gerenciador gerenciador)
    {
        driver = gerenciador.drive;
        url = "https://localhost:7065/Leiloes";
        _btnAdicionarLeilao = By.CssSelector("div div div div div h4 a i");
        _loginPO = new LoginPO(gerenciador);
    }

    [Fact]
    public void NavegarCadastroDeLeilao()
    {
        // Arrange
        _loginPO.FazerLoginAdmVerificarRetorno();
       
        // Act
        driver.FindElement(_btnAdicionarLeilao).Click();

        // Assert
        Assert.Equal($"{url}/Novo", driver.Url);
    }

    [Fact]
    public void NavegarParaLeilaoNaoIniciado()
    {
        // Arrange
        _loginPO.FazerLoginVerificarSeLogou();

        // Act
        driver.Navigate().GoToUrl("https://localhost:7065/Home/Detalhes/22");

        // Assert
        Assert.Contains("Pregão não iniciado", driver.PageSource);
    }

    [Fact]
    public void NavegarParaLeilaoEncerrado()
    {
        // Arrange
        _loginPO.FazerLoginVerificarSeLogou();

        // Act
        driver.Navigate().GoToUrl("https://localhost:7065/Home/Detalhes/5");

        // Assert
        Assert.Contains("Pregão encerrado", driver.PageSource);
    }

    [Fact]
    public void NavegarParaLeilaoEmAndamento()
    {
        // Arrange
        _loginPO.FazerLoginVerificarSeLogou();

        // Act
        driver.Navigate().GoToUrl("https://localhost:7065/Home/Detalhes/1");

        // Assert
        Assert.Contains("Pregão em andamento", driver.PageSource);
    }

    [Fact]
    public void NavegarParaConsultaLeilao()
    {
        // Arrange
        // Act
        _loginPO.FazerLoginVerificarSeLogou();

        // Assert
        Assert.Contains("Pesquisar Leilões", driver.PageSource);
        Assert.Equal("https://localhost:7065/Interessadas", driver.Url);
    }
}
