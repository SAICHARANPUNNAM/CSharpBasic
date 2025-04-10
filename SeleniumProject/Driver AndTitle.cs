using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumLearning
{
    class Driver_AndTitle
    {
        IWebDriver dr;
        
        [SetUp]
        public void CreateDriver()
        {
            dr = new ChromeDriver();
            //dr = new FirefoxDriver();
            //dr = new EdgeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://www.makemytrip.com/");
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }
        [Test]
        public void Title()
        {
            Console.WriteLine(dr.Title);
            Console.WriteLine(dr.Url);


        }
        [TearDown]
        public void CloseBrowser()
        {
            dr.Quit();
            dr.Dispose();
        }
    }
}
