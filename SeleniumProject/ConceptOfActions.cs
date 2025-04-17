using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumProject
{
    public class ConceptOfActions
    {


        IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/");
        }
        [Test]
        public void VerifyMoveToElement()
        {
            Actions actionElement = new Actions(dr);
            actionElement.MoveToElement(dr.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            Thread.Sleep(3000);
            //dr.FindElement(By.XPath("//ul[@class='dropdown-menu'][1]/li[2]/a")).Click();
            actionElement.MoveToElement(dr.FindElement(By.XPath("//ul[@class='dropdown-menu'][1]/li[2]/a"))).Click().Perform();
            dr.Close();
        }
        [Test]
        public void VerifyDragAndDrop()
        {
            dr.Navigate().GoToUrl("https://demo.guru99.com/test/drag_drop.html");
            Actions actionElement = new Actions(dr);
            actionElement.DragAndDrop(dr.FindElement(By.XPath("//div[@class='ui-widget-content']/ul/li[5]/a")), dr.FindElement(By.XPath("(//div[@class='ui-widget-content'])[2]"))).Perform();
            actionElement.DragAndDrop(dr.FindElement(By.XPath("//div[@class='ui-widget-content']/ul/li[2]/a")), dr.FindElement(By.XPath("(//div[@class='ui-widget-content'])[3]"))).Perform();
            actionElement.DragAndDrop(dr.FindElement(By.XPath("//div[@class='ui-widget-content']/ul/li[6]/a")), dr.FindElement(By.XPath("(//div[@class='ui-widget-content'])[4]"))).Perform();
            actionElement.DragAndDrop(dr.FindElement(By.XPath("//div[@class='ui-widget-content']/ul/li[2]/a")), dr.FindElement(By.XPath("(//div[@class='ui-widget-content'])[5]"))).Perform();

        }
    }
}