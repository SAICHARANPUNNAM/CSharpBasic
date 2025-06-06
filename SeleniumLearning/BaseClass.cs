using System;
using System.Collections.Generic;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

using OpenQA.Selenium.Interactions;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace SeleniumLearning
{
    class BaseClass
    {
        public IWebDriver dr;
        [SetUp]
        public void Setup()
        {


            ChromeOptions options = new ChromeOptions();
            


            dr = new ChromeDriver();

            //dr.Navigate().GoToUrl("https://www.ironspider.ca/forms/checkradio.htm");
            //dr.Navigate().GoToUrl("https://www.google.com");
            dr.Navigate().GoToUrl("https://www.Amazon.in");
            
            dr.Manage().Window.Maximize();
            Thread.Sleep(10000);
        }


        [TearDown]
        public void Cleanup()
        {
            Thread.Sleep(5000);
            dr.Quit();
            dr.Dispose();
        }
    }
}
