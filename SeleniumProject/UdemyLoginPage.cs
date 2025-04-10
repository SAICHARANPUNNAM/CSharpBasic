using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject
{
    class UdemyLoginPage
    {
        IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");

        }
        [Test]
        public void EndToEndFlow()
        {
            dr.FindElement(By.CssSelector("#username")).SendKeys("rahulshettyacademy");
            dr.FindElement(By.CssSelector("#password")).SendKeys("learning");
            dr.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            dr.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            dr.FindElement(By.CssSelector("#signInBtn")).Click();
            //WebDriverWait wait  = new WebDriverWait(dr, TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible())
            //dr.Close();
        }
    }
}
