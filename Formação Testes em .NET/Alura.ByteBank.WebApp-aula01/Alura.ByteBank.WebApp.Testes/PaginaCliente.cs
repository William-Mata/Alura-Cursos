using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Reflection;
using Xunit.Abstractions;
using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Utils;

namespace Alura.ByteBank.WebApp.Testes;

public class PaginaCliente : IClassFixture<GerenciadorNavegador>
{
    private IWebDriver _driver;
    public ITestOutputHelper Output;

    public PaginaCliente(ITestOutputHelper output, GerenciadorNavegador gerenciador)
    {
        this._driver = gerenciador.driver;
        Output = output;
    }

    [Fact]
    public void CadastrarCliente()
    {
        // Arrange
        _driver.FindElement(By.LinkText("Cliente")).Click();
        _driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

        _driver.FindElement(By.Id("Identificador")).SendKeys("4f609b2f-d091-4af6-9c58-b8775ed93e14");
        _driver.FindElement(By.Id("CPF")).SendKeys("153.375.520-58");
        _driver.FindElement(By.Id("Nome")).SendKeys("teste123");
        _driver.FindElement(By.Id("Profissao")).SendKeys("Dev");

        // Act
        _driver.FindElement(By.ClassName("btn-primary")).Click();

        // Assert
        Assert.Contains("Clientes", _driver.PageSource);
        Assert.Contains("https://localhost:44309/Clientes/Index", _driver.Url);
    }

    public void Dispose()
    {
        _driver.Close();
    }
}
