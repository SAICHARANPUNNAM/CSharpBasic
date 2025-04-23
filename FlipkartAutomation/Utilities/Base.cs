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
            // we will configration something Global entire the application using file-->General-->appconfin..
            //Add package system.configuration manager..
            string browserName = ConfigurationManager.AppSettings["browser"];

            InitBrowser(browserName);
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/seleniumPractise/#/");

        }
        public void InitBrowser(string browserName)
        {          //Factory design pattern
            switch (browserName)
            {
                case "Firefox":
                    dr = new FirefoxDriver();
                    break;
                case "Chrome":
                    dr = new ChromeDriver();
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
