using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject
{
    class UdemyLoginPage
    {
        IWebDriver dr;
        [SetUp]
        public void StartBrowser()
        {
            dr = new ChromeDriver();
            dr.Manage().Window.Maximize();
            dr.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            dr.Navigate().GoToUrl("https://rahulshettyacademy.com/loginpagePractise/");

        }
        [Test]
        public void EndToEndFlow()
        {
            string[] expectedProducts = { "iphone X", "Nokia Edge", "Blackberry" }; // Fixed typo in variable name
            dr.FindElement(By.CssSelector("#username")).SendKeys("rahulshettyacademy");
            dr.FindElement(By.CssSelector("#password")).SendKeys("learning");
            dr.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            dr.FindElement(By.CssSelector("#signInBtn")).Click();
            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            IList<IWebElement> products = dr.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text)) // Fixed typo in variable name
                {
                    //IWebElement button = product.FindElement(By.CssSelector(".card-footer button"));
                    //((IJavaScriptExecutor)dr).ExecuteScript("arguments[0].click();", button);

                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }
            
            dr.FindElement(By.PartialLinkText("Checkout")).Click();
            //dr.Close();
        }
    }
}
