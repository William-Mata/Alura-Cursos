using Alura.ByteBank.WebApp.Testes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Testes.Utils;

public class GerenciadorNavegador : IDisposable
{
    public IWebDriver driver;
    private LoginPO _loginPO;

    public GerenciadorNavegador()
    {
        this.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        _loginPO = new LoginPO(this);
        _loginPO.NavegarParaTelaDeLogin();
        _loginPO.PreencherCamposLogar("william@email.com", "senha01");
    }

    public void Dispose()
    {
        driver.Quit();
    }
}
