﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
namespace SeleniumLearning
{
    class Locators
    {
        [Test]
        public void LocatorIdentifications()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://www2.hm.com/en_in/index.html");
            dr.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            //WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Sign in']")));
            dr.FindElement(By.XPath("(//span[text()='Sign in'])[1]")).Click();
            dr.FindElement(By.Name("email")).SendKeys("punnamsaicharan0011");
            dr.FindElement(By.Id("password")).SendKeys("Charansai@0011");
            dr.FindElement(By.XPath("(//span[text()='Sign in'])[2]")).Click();
            string error = dr.FindElement(By.XPath("//span[@class='x_nB JJAS gwYl']")).Text;
            Console.WriteLine(error);
            dr.FindElement(By.XPath("(//button[@type='button'])[13]")).Click();

            IWebElement Link = dr.FindElement(By.LinkText("Men"));

            string actualUrl = Link.GetAttribute("href");
            string expectedUrl = "https://www2.hm.com/en_in/women.html";
            Assert.That(actualUrl, Is.EqualTo(expectedUrl)); // Updated assertion method

            dr.Close();
        }
    }
}
