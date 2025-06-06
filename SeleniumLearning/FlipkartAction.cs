using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    class FlipkartAction
    {

        [Test]
        public void VerifyScrolToElement()
        {
            IWebDriver dr = new ChromeDriver();

            dr.Manage().Window.Maximize();

            dr.Navigate().GoToUrl("https://www.Flipkart.com/");
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement element = dr.FindElement(By.LinkText("About Us"));
            Actions scrolDown = new Actions(dr);
            scrolDown.ScrollToElement(element).Build().Perform();
            Thread.Sleep(5000);
            element.Click();
        }
    }
}
