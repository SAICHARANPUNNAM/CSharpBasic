using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumLearning
{
    class Driver_AndTitle
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        IWebDriver dr;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        
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
