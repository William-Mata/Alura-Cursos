using Alura.LeilaoOnline.Selenium.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

[Collection("Chrome Driver")]
public class CadastroLeilaoPO : PadraoPO
{
    private By _tituloLeilao;
    private By _descricaoLeilao;
    private By _categoriaLeilao;
    private By _valorIncialLeilao;
    private By _inicioPregraoLeilao;
    private By _terminioPregraoLeilao;
    private By _btnAddImgLeilao;
    private By _btnSalvarLeilao;
    private NavegarLeilaoPO _leilao;

    public CadastroLeilaoPO(Gerenciador gerenciador)
    {
        _leilao = new NavegarLeilaoPO(gerenciador);
        driver = gerenciador.drive;
        url = "https://localhost:7065/Leiloes/Novo";
        _tituloLeilao = By.Id("Titulo");
        _descricaoLeilao = By.Id("Descricao");
        _categoriaLeilao = By.Id("Categoria");
        _valorIncialLeilao = By.Id("ValorInicial");
        _inicioPregraoLeilao = By.Id("InicioPregao");
        _terminioPregraoLeilao = By.Id("TerminoPregao");
        _btnAddImgLeilao = By.Id("ArquivoImagem");
        _btnSalvarLeilao = By.CssSelector("div .card-action button");
    }

    [Fact]
    public void CadastrarLeilao()
    {
        // Arrange
        _leilao.NavegarCadastroDeLeilao();
        driver.FindElement(_tituloLeilao).SendKeys("Moto Reliquia");
        driver.FindElement(_descricaoLeilao).SendKeys(@"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin convallis augue sed urna rutrum facilisis.");
        driver.FindElement(_valorIncialLeilao).SendKeys("1000.00");
        driver.FindElement(_inicioPregraoLeilao).SendKeys(DateTime.Now.ToString("dd/MM/yyyy"));
        driver.FindElement(_terminioPregraoLeilao).SendKeys(DateTime.Now.AddDays(10).ToString("dd/MM/yyyy"));
        driver.FindElement(_btnAddImgLeilao).SendKeys("C:/Users/willi/OneDrive/Documentos/GitHub/Alura-Cursos/Formação Testes em .NET/Selenium.Tests2/Alura.LeilaoOnline.WebApp/wwwroot/images/motoLeilao.jpg");

        // Forma 1 - lidando com select
        var categoriaSelect = driver.FindElement(_categoriaLeilao);
        //var categoriaOption = categoriaSelect.FindElements(By.CssSelector("li span")).FirstOrDefault(x => x.Text == "Item de Colecionador

        // Forma 2 
        SelectElement select = new SelectElement(categoriaSelect);
        select.SelectByText("Item de Colecionador");

        // Act
        driver.FindElement(_btnSalvarLeilao).Click();

        // Assert
        Assert.Equal(url, driver.Url);
    }
}
