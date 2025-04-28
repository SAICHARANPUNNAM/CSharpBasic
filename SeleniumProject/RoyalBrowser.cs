using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLearning
{

    class RoyalBrowser
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IWebDriver dr;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [SetUp]
        public void CreateDriver()
        {
            dr = new ChromeDriver();
            //dr = new FirefoxDriver();
            //dr = new EdgeDriver();
            dr.Manage().Window.Maximize();

            
            dr.Navigate().GoToUrl("https://www.royalenfield.com");


        }
        [Test]
        public void VerifyLoginPage()
        {
            dr.FindElement(By.Id("customGDPR")).Click();
            dr.FindElement(By.ClassName("login-link")).Click();
            dr.FindElement(By.CssSelector("input[placeholder='Email/Mobile Number']")).SendKeys("8499848849");
            dr.FindElement(By.Name("password")).SendKeys("Charansai@0568");
            dr.FindElement(By.Id("submit-login")).Click();
            //dr.FindElement(By.XPath("//button[text()='Ok']")).Click();
           
            string error = dr.FindElement((By.XPath("(//div[@class='modal-body'])[1]"))).Text;
            Console.WriteLine(error);
            //Assert.AreEqual(error, "The password you entered is incorrect. Please try again.");
            //IAlert alert = dr.SwitchTo().Alert();
            //string alertMessage = dr.SwitchTo().Alert().Text;
            //Console.WriteLine(alertMessage);

            dr.Close();
        }
    }
}
