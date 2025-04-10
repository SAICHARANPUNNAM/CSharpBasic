using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;


namespace SeleniumLearning
{
    public class CssLocators
    {
        [Test]
        public void VerifyCssLocators()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            // implicit wait works on globally while excuting code check the element and it will there in 2 sec it will run but there is no element wait for 5 second and error will be displayed on console.
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");
            driver.FindElement(By.CssSelector("#username")).SendKeys("Sai Charan");
            driver.FindElement(By.CssSelector("#password")).SendKeys("Charansa@12");
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            //driver.FindElement(By.CssSelector(".text-info span input")).Click();
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            driver.FindElement(By.CssSelector("#signInBtn")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.CssSelector("#signInBtn")), "Sign In"));
            string error = driver.FindElement(By.ClassName("alert-danger")).Text;
            Console.WriteLine(error);
            IWebElement displayLink = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));  
            string verifyDisplayLink = displayLink.GetAttribute("href");
            Console.Write(verifyDisplayLink);
            string actualValue = "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(verifyDisplayLink, actualValue);

            //driver.Close();

        }
    }
}
