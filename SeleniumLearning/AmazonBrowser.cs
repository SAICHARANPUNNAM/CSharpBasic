using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SeleniumLearning
{
    class AmazonBrowser : BaseClass
    {


        [Test]
        public void VerifyHomePage()
        {
            dr.FindElement(By.Id("nav-link-accountList")).Click();
            //dr.FindElement(By.XPath("/html/body/div/header/div/div/div[17]/div[2]/a/span")).Click();
            Thread.Sleep(2000);
            dr.FindElement(By.XPath("//input[@type='email']")).SendKeys("Charancherry12354@gmail.com");
            dr.FindElement(By.Id("continue")).Click();
            dr.FindElement(By.XPath("//input[@type='password']")).SendKeys("Charansai@0568");
            dr.FindElement(By.Id("signInSubmit")).Click();
            Thread.Sleep(10000);
            dr.FindElement(By.XPath("//input[@type='text']")).SendKeys("Sony TV 55 inch");
            dr.FindElement(By.Id("nav-search-submit-button")).Click();
            dr.FindElement(By.XPath("(//a[contains(@class,'a-link-normal s-line-clamp-2 s-link-style a-text-normal')])[3]")).Click();
            Thread.Sleep(5000);
            ReadOnlyCollection<string> nextpage = dr.WindowHandles;
            dr.SwitchTo().Window(nextpage[1]);
            dr.FindElement(By.XPath("(//input[@value='Add to cart'])[2]")).Click();
            
        }



    }
}
