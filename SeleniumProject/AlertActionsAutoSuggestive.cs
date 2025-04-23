using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumProject
{
    class AlertActionsAutoSuggestive
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
        public void test_Alert()
        {
            string name = "Rahul";
            dr.FindElement(By.CssSelector("#name")).SendKeys(name);
            dr.FindElement(By.CssSelector("input[onclick*='displayConfirm")).Click();
            string alertText = dr.SwitchTo().Alert().Text;
            TestContext.Progress.Write(alertText);
            dr.SwitchTo().Alert().Accept();
            //dr.SwitchTo().Alert().Dismiss();
            //it will on alert input box empty we should write like this
            //dr.SwitchTo().Alert().SendKeys("");
            StringAssert.Contains(name, alertText);
            dr.Close();
        }


    }
}
