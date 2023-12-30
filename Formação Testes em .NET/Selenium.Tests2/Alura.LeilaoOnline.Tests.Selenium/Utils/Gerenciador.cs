

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
        //drive.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //drive.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
        //drive.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        drive.Navigate().GoToUrl(_url);
    }

    public void Dispose()
    {
        drive.Quit();  
    }
}
