using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumProject
{
    public class DynamicDropDown
    {
        IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl(" https://rahulshettyacademy.com/AutomationPractice/");
        }
        [Test]
        public void AutoSuggestionDropDown()
        {
            dr.FindElement(By.CssSelector("input#autocomplete")).SendKeys("ind");
           
            IList<IWebElement> options = dr.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
            }
            Console.WriteLine(dr.FindElement(By.CssSelector("input#autocomplete")).GetAttribute("value"));
        }
    }
}
