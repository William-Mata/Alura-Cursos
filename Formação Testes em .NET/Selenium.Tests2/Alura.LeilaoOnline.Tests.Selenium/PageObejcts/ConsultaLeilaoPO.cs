using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

[Collection("Chrome Driver")]
public class ConsultaLeilaoPO : PadraoPO
{
    private By _termoConsultaLeilao;
    private By _andamentoConsultaLeilao;
    private By _btnConsultarLeilao;
    private By _categoriaConsultaLeilao;
    private NavegarLeilaoPO _leilao;

    public ConsultaLeilaoPO(Gerenciador gerenciador)
    {
        _leilao = new NavegarLeilaoPO(gerenciador);
        driver = gerenciador.drive;
        url = "https://localhost:7065/Interessadas";
        _btnConsultarLeilao = By.TagName("button");
        _categoriaConsultaLeilao = By.ClassName("select-wrapper");
        _termoConsultaLeilao = By.Id("termo");
        _andamentoConsultaLeilao = By.ClassName("lever");
    }

    [Fact]
    public void ConsultarLeilaoComFiltros()
    {
        // Arrange
        _leilao.NavegarParaConsultaLeilao();
        driver.FindElement(_termoConsultaLeilao).SendKeys("Leilão de Carro");
        driver.FindElement(_andamentoConsultaLeilao).Click();
        string[] categoriasSelecioanr = { "Automóveis", "Coleções" };

        // PEGA O SELECT
        var categoriaSelect = driver.FindElement(_categoriaConsultaLeilao);
        categoriaSelect.Click();
        Thread.Sleep(10);
        // PERCORRE AS OPTION DO SELECT E MARCA AS OPCOES FORNECIDAS
        categoriaSelect.FindElements(By.CssSelector("li>span>label"))
            .Where(x => !categoriasSelecioanr.Any(y => y == x.Text))
            .ToList().ForEach(x => x.Click());

        Thread.Sleep(10);
        // TIRA O FOCO DO SELECT 
        categoriaSelect.FindElement(By.TagName("li")).SendKeys(Keys.Tab);

        // Act
        driver.FindElement(_btnConsultarLeilao).Click();
        var result = driver.FindElement(By.TagName("table")).FindElements(By.CssSelector("tbody>tr")).Count();

        // Assert
        Assert.Equal("https://localhost:7065/Interessadas", driver.Url);
        Assert.True(result == 2);
    }
}
