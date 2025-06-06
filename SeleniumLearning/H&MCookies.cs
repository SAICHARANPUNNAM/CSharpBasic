using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    class H_MCookies
    {
        [Test]
        public void AddCookies()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("http://google.com");
            Cookie cookies1 = new Cookie("username", "Sai charan");
            dr.Manage().Cookies.AddCookie(cookies1);
            Console.WriteLine(cookies1);
        }
    }
}
