

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Alura.LeilaoOnline.Selenium.Utils;

public class Gerenciador : IDisposable
{
    public IWebDriver drive;
    private string _url = "https://localhost:7065/";

    public Gerenciador()
    {
        drive = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        drive.Navigate().GoToUrl(_url);
    }

    public void Dispose()
    {
        drive.Quit();  
    }
}
