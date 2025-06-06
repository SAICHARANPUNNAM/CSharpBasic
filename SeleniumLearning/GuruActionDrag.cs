using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    class GuruActionDrag
    {
        [Test]
        public void DragAndDropElement()
        {
            IWebDriver dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("https://demo.guru99.com/test/drag_drop.html");
            IWebElement From = dr.FindElement(By.Id("credit2"));
            IWebElement To = dr.FindElement(By.Id("bank"));
            IWebElement From1 = dr.FindElement(By.XPath("(//a[@class='button button-orange'])[2]"));
            IWebElement To1 = dr.FindElement(By.Id("amt7"));
            IWebElement From2 = dr.FindElement(By.Id("credit1"));
            IWebElement To2 = dr.FindElement(By.Id("loan"));
            IWebElement From3 = dr.FindElement(By.XPath("(//a[@class='button button-orange'])[2]"));
            IWebElement To3 = dr.FindElement(By.Id("amt8"));
            Actions action = new Actions(dr);
            action.DragAndDrop(From, To).Build().Perform();
            action.DragAndDrop(From1, To1).Build().Perform();
            action.DragAndDrop(From2, To2).Build().Perform();
            action.DragAndDrop(From3, To3).Build().Perform();

        }
    }
}
