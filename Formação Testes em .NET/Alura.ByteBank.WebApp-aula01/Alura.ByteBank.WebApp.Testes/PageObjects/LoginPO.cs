using Alura.ByteBank.WebApp.Testes.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.ByteBank.WebApp.Testes.PageObjects;

public class LoginPO : IClassFixture<GerenciadorNavegador>
{
    private IWebDriver _driver;
    private By _campoEmail;
    private By _campoSenha;
    private By _btnLogar;
    private string _url = "https://localhost:44309/UsuarioApps/Login";


    public LoginPO(GerenciadorNavegador gerenciador)
    {
        _driver = gerenciador.driver;
        _campoEmail = By.Id("Email");
        _campoSenha = By.Id("Senha");
        _btnLogar = By.Id("btn-logar");
    }

    public void NavegarParaTelaDeLogin()
    {
        _driver.Navigate().GoToUrl(_url);
    }

    public void PreencherCamposLogar(string email, string senha)
    {
        _driver.FindElement(_campoEmail).SendKeys(email);
        _driver.FindElement(_campoSenha).SendKeys(senha);
        _driver.FindElement(_btnLogar).Click();
    }
}
