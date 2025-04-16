using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace SeleniumProject
{

    public class SortWebTable
    {
        IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/seleniumPractise/#/");
        }
        [Test]
        public void SortTable()
        {
            ArrayList arrayList = new ArrayList();
            //WebDriverWait wait = new WebDriverWait(dr,TimeSpan.FromSeconds(8));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Top Deals']")));
            //dr.FindElement(By.XPath("//a[text()='Top Deals']")).Click();
            dr.FindElement(By.LinkText("Top Deals")).Click();
            var tabs = dr.WindowHandles;
            dr.SwitchTo().Window(tabs[1]);
            SelectElement dropDown = new SelectElement(dr.FindElement(By.CssSelector("select[id=page-menu]")));
            dropDown.SelectByValue("20");
            IList<IWebElement> veggies = dr.FindElements(By.XPath("//tr//td[1]"));
            foreach (IWebElement veggie in veggies)
            {
                arrayList.Add(veggie.Text);
            }
            arrayList.Sort();
            foreach (string element in arrayList)
            {
                Console.WriteLine(element);
            }
            // th[aria-label*='fruit name'] this is css when conatins substring using*
            dr.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();
            ArrayList arrayList2 = new ArrayList();
            IList<IWebElement> sortVeggies = dr.FindElements(By.XPath("//tr//td[1]"));
            foreach (IWebElement veggie in sortVeggies)
            {
                arrayList2.Add(veggie.Text);
               
            }
            Assert.AreEqual(arrayList, arrayList2);
            dr.Close();
        }
    }
}
