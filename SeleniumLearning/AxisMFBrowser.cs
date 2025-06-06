using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;




namespace SeleniumLearning
{
    class AxisMFBrowser
    {
        [Test, Category("Handling Multiple Windows")]
        public void VerifyLoginPage()
        {
            IWebDriver dr = new ChromeDriver();

            dr.Manage().Window.Maximize();

            dr.Navigate().GoToUrl("https://www.axismf.com/");
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            dr.FindElement(By.Id("nvpush_cross")).Click();
            dr.FindElement(By.XPath("//ion-button[contains(text(),'Login')]")).Click();
            //   dr.FindElement(By.Id("notify-visitors-notification-close-button_29237")).Click();
            dr.FindElement(By.XPath("(//input[@class='native-input sc-ion-input-md'])[6]")).SendKeys("1215");
            IWebElement Error = dr.FindElement(By.XPath("//*[text()='Please enter a correct PAN']"));
            Assert.IsTrue(Error.Size != Size.Empty, "Error msg not Displayed");

            dr.Close();
        }
    }
}
