using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    class TutorialzActionDouble
    {
        [Test]
        public void VerifyDoubleClick()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://techtutorialz.com/");
            Actions doubleClick = new Actions(dr);
            doubleClick.DoubleClick(dr.FindElement(By.XPath("//a[text()='Request a Demo']"))).Build().Perform();

        }
        [Test]
        public void GuruDoubleClick()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://demo.guru99.com/test/simple_context_menu.html");
            Actions action = new Actions(dr);
            IWebElement Guru99 = dr.FindElement(By.XPath("//button[text()='Double-Click Me To See Alert']"));
            action.DoubleClick(Guru99).Build().Perform();
        }
    }
}
