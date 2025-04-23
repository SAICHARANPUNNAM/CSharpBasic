using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace CSharpSelFramework.Utilities
{
    public class Base
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public IWebDriver dr;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }
        public IWebDriver getDriver()
        {
            return dr;
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
