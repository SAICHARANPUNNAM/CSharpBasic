using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSharpSelFramework
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
            string[] actualProducts = new string[3];
            dr.FindElement(By.CssSelector("#username")).SendKeys("rahulshettyacademy");
            dr.FindElement(By.CssSelector("#password")).SendKeys("learning");
            dr.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();
            dr.FindElement(By.CssSelector("#signInBtn")).Click();

            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            IList<IWebElement> products = dr.FindElements(By.TagName("app-card"));
            foreach (IWebElement product in products)
            {
                Thread.Sleep(3000);
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text)) // Fixed typo in variable name
                {

                    // IWebElement button = product.FindElement(By.CssSelector(".card-footer button"));
                    //((IJavaScriptExecutor)dr).ExecuteScript("arguments[0].click();", button);
                    //IJavaScriptExecutor js = (IJavaScriptExecutor)dr;
                    //js.ExecuteScript("arguments[0].click();", button);
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                Console.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            dr.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> checkoutList = dr.FindElements(By.CssSelector("h4 a"));
            for (int i = 0; i < checkoutList.Count; i++)
            {
                actualProducts[i] = checkoutList[i].Text;

            }
            Assert.AreEqual(expectedProducts, actualProducts);
            // now click on checkout
            dr.FindElement(By.CssSelector(".btn-success")).Click();
            dr.FindElement(By.Id("country")).SendKeys("Ind");
            dr.FindElement(By.LinkText("India")).Click();
            dr.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            dr.FindElement(By.CssSelector("input[value='Purchase']")).Click();
            string successTxt = dr.FindElement(By.CssSelector("div.alert ")).Text;
            Console.WriteLine(successTxt);
            // now we will check success test present or not
            StringAssert.Contains("Success", successTxt);
            Thread.Sleep(3000);
            dr.Close();
        }
    }
}
