using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumProject
{
    public class DynamicDropDown
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        IWebDriver dr;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
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
