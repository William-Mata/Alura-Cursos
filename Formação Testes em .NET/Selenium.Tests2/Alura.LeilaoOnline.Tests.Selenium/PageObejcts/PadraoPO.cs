using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Tests.Selenium.PageObejcts;

public abstract class PadraoPO
{
    protected IWebDriver driver;
    protected LoginPO _loginPO;
    protected string url;
}
