using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLearning
{
    class GoogleHomePage
    {
        [Test]
        public void GetValue()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://www.google.com");
            //dr.FindElement(By.LinkText("Gmail")).Click();
            IWebElement element =  dr.FindElement(By.Name("q"));
            string mlength = element.GetAttribute("maxlength");
            Console.WriteLine("C heck1");
            Console.WriteLine(mlength);
            Assert.IsTrue(mlength == "2048");
            dr.Close();

        }
    }
}
