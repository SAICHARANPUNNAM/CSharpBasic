using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    class ActionRightClick
    {
        [Test]
        public void RightClickOnElement()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://techtutorialz.com/");
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Actions rightClick = new Actions(dr);
            rightClick.ContextClick(dr.FindElement(By.XPath("//a[text()='View Tutorial Library']"))).Build().Perform();
            
        }
        [Test]
        public void VerifyRightClick()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://demo.guru99.com/test/simple_context_menu.html");
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Actions rightClick = new Actions(dr);
            rightClick.ContextClick(dr.FindElement(By.XPath("//span[text()='right click me']"))).Build().Perform();
            IWebElement element = dr.FindElement(By.XPath("//span[text()='Delete']"));
            string elementText = element.GetAttribute("innerText");
            Console.WriteLine("Element text: " + elementText);
            Assert.IsTrue(element.GetAttribute("innerText") == "Delete");
            dr.Close();
            // Assert.IsTrue(element.Size != Size.Empty, "Error msg not Displayed");


        }
    }
}
