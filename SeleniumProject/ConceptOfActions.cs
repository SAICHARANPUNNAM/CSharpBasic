using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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
        [Test]
        public void VerifyDoubleClick()
        {
            dr.Navigate().GoToUrl("https://qa-practice.netlify.app/");
            Actions actionDouble = new Actions(dr);
            actionDouble.MoveToElement(dr.FindElement(By.CssSelector("#actions"))).Click().Perform();
            actionDouble.MoveToElement(dr.FindElement(By.Id("double-click"))).Click().Perform();
            actionDouble.DoubleClick(dr.FindElement(By.Id("double-click-btn"))).Perform();
            string doubleClick = dr.FindElement(By.Id("double-click-result")).Text;
            Console.WriteLine(doubleClick);
            string actualValue = "Congrats, you double clicked!";
            Assert.AreEqual(actualValue, doubleClick);
        }
        [Test]
        public void VerifyRightClick()
        {
            dr.Navigate().GoToUrl("https://techtutorialz.com/");

            Actions actionRight = new Actions(dr);
            actionRight.MoveToElement(dr.FindElement(By.Id("menu-item-1301"))).Perform();
            Thread.Sleep(3000);
            actionRight.ContextClick(dr.FindElement(By.Id("menu-item-1301"))).Perform();

        }
        [Test]
        public void VerifyKeyDown()
        {
            dr.Navigate().GoToUrl("https://www.amazon.in/");

            Actions actionKeyDown = new Actions(dr);
            IWebElement searchBox = dr.FindElement(By.CssSelector("#twotabsearchtextbox"));
            actionKeyDown.Click(searchBox)
               .KeyDown(Keys.Shift)        // Press Shift
               .SendKeys("hello")          // Types HELLO
               .KeyUp(Keys.Shift)          // Release Shift
               .SendKeys(" world")         // Types normally
               .SendKeys(Keys.Enter)       // Submits the search
               .Build()
               .Perform();
        }
        [Test]
        public void VerifyScrollElement()
        {
            dr.Navigate().GoToUrl("https://www.amazon.in/");

            Actions actionScroll = new Actions(dr);
            IWebElement element = dr.FindElement(By.XPath("//div[text()='Make Money with Us']"));
            //actionScroll.ScrollToElement(element).Perform();

            IJavaScriptExecutor js = (IJavaScriptExecutor)dr;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(3000);
        }
        [Test]
        public void VerifyFrame()
        {
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            IWebElement frameScroll = dr.FindElement(By.Name("iframe-name"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)dr;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("courses-iframe")));
            dr.SwitchTo().Frame("courses-iframe");

            dr.FindElement(By.LinkText("All Access Plan")).Click();
            Console.WriteLine(dr.FindElement(By.CssSelector("h1")).Text);
            dr.SwitchTo().DefaultContent();
            Console.WriteLine(dr.FindElement(By.CssSelector("h1")).Text);
        }
        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(3000);
            dr.Quit();
            dr.Dispose();
        }
    }
}