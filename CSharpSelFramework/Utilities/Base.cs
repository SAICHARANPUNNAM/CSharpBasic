using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace CSharpSelFramework.Utilities
{
    public class Base
    {
        public IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            // We can configuration all file golbally in to the application--NewItem->general->App-confi..select
            /*Add this on app confi--<appSettings>
            <add key = "browser" value="Chrome"/>
            </appSettings>*/
            string browserName = ConfigurationManager.AppSettings["browser"];
            // window confi also you need to add in editfile in project you add two lines of code..to run appsetting
            InitBrowser(browserName);
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/seleniumPractise/#/");
        }
        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    dr = new ChromeDriver();
                    break;
                case "Firefox":
                    dr = new FirefoxDriver();
                    break;
                case "Edge":
                    dr = new EdgeDriver();
                    break;
            }

        }
        [TearDown]
        public void CloseBrowser()
        {
            dr.Quit();
            dr.Dispose();
        }
    }
}
