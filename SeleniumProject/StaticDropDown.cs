using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    // Handling DropDown there are two type dropdowns 1.Static dropdown 2.Dynamic dropdown
    //Static dropdown is already displayed just we hav to select. it accept with using "select class".
    public class StaticDropDown
    {
        private IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
        }
        [Test]
        public void DropDown()
        {
            IWebElement drop = dr.FindElement(By.CssSelector("select.form-control"));
            SelectElement down = new SelectElement(drop);
            down.SelectByText("Teacher");
            down.SelectByValue("stud");
            down.SelectByIndex(2);
            //dr.Close();
        }

    }
}
